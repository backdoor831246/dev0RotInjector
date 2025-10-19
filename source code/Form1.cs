using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace dev0RotInjector
{
    public partial class Form1 : Form
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(uint processAccess, bool bInheritHandle, int processId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const uint PROCESS_ALL_ACCESS = 0x1F0FFF;
        private const uint MEM_COMMIT = 0x1000;
        private const uint MEM_RESERVE = 0x2000;
        private const uint PAGE_EXECUTE_READWRITE = 0x40;

        private Process[] processes;

        public Form1(string dllPath = "")
        {
            InitializeComponent();
            if (!string.IsNullOrEmpty(dllPath))
            {
                txtDllPath.Text = dllPath;
            }
            LoadProcesses();
            lblGitHub.Links.Add(0, lblGitHub.Text.Length, "https://github.com/backdoor831246");
        }

        private void LoadProcesses(string filter = "")
        {
            comboBoxProcesses.Items.Clear();
            processes = Process.GetProcesses().OrderBy(p => p.ProcessName).ToArray();
            foreach (var process in processes)
            {
                string displayText = $"{process.ProcessName} (PID: {process.Id})";
                if (string.IsNullOrEmpty(filter) || displayText.ToLower().Contains(filter.ToLower()) || process.Id.ToString().Contains(filter))
                {
                    comboBoxProcesses.Items.Add(displayText);
                }
            }
            if (comboBoxProcesses.Items.Count > 0)
                comboBoxProcesses.SelectedIndex = 0;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "DLL Files (*.dll)|*.dll";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    txtDllPath.Text = ofd.FileName;
                }
            }
        }

        private void btnInject_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDllPath.Text) || !System.IO.File.Exists(txtDllPath.Text))
            {
                MessageBox.Show("Please select a valid DLL file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (comboBoxProcesses.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int pid;
            string selected = comboBoxProcesses.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(txtPid.Text) && int.TryParse(txtPid.Text, out pid))
            {
                if (!processes.Any(p => p.Id == pid))
                {
                    MessageBox.Show("Invalid or non-existent PID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else if (!string.IsNullOrEmpty(selected))
            {
                int pidStart = selected.LastIndexOf("PID: ") + 5;
                int pidEnd = selected.LastIndexOf(")");
                if (!int.TryParse(selected.Substring(pidStart, pidEnd - pidStart), out pid))
                {
                    MessageBox.Show("Invalid PID in selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please select a process or enter a valid PID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
                if (hProcess == IntPtr.Zero)
                {
                    MessageBox.Show("Failed to open process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string dllPath = txtDllPath.Text;
                byte[] dllPathBytes = System.Text.Encoding.ASCII.GetBytes(dllPath + "\0");
                IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPathBytes.Length, MEM_COMMIT | MEM_RESERVE, PAGE_EXECUTE_READWRITE);
                if (allocMemAddress == IntPtr.Zero)
                {
                    CloseHandle(hProcess);
                    MessageBox.Show("Failed to allocate memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!WriteProcessMemory(hProcess, allocMemAddress, dllPathBytes, (uint)dllPathBytes.Length, out IntPtr bytesWritten))
                {
                    CloseHandle(hProcess);
                    MessageBox.Show("Failed to write memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                if (loadLibraryAddr == IntPtr.Zero)
                {
                    CloseHandle(hProcess);
                    MessageBox.Show("Failed to get LoadLibraryA address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                IntPtr hThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, out IntPtr threadId);
                if (hThread == IntPtr.Zero)
                {
                    CloseHandle(hProcess);
                    MessageBox.Show("Failed to create remote thread.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                CloseHandle(hThread);
                CloseHandle(hProcess);
                MessageBox.Show("DLL injected successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Injection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtPid.Text = "";
            LoadProcesses();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProcesses(txtSearch.Text);
        }

        private void lblGitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo(e.Link.LinkData.ToString()) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to open link: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}