namespace dev0RotInjector
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblDllPath = new System.Windows.Forms.Label();
            this.txtDllPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblProcess = new System.Windows.Forms.Label();
            this.comboBoxProcesses = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnInject = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtPid = new System.Windows.Forms.TextBox();
            this.lblPid = new System.Windows.Forms.Label();
            this.lblGitHub = new System.Windows.Forms.LinkLabel();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDllPath
            // 
            this.lblDllPath.AutoSize = true;
            this.lblDllPath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDllPath.Location = new System.Drawing.Point(20, 20);
            this.lblDllPath.Name = "lblDllPath";
            this.lblDllPath.Size = new System.Drawing.Size(60, 15);
            this.lblDllPath.TabIndex = 0;
            this.lblDllPath.Text = "DLL Path:";
            // 
            // txtDllPath
            // 
            this.txtDllPath.Location = new System.Drawing.Point(90, 18);
            this.txtDllPath.Name = "txtDllPath";
            this.txtDllPath.Size = new System.Drawing.Size(400, 23);
            this.txtDllPath.TabIndex = 1;
            this.txtDllPath.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowse.Location = new System.Drawing.Point(500, 18);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(90, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblProcess
            // 
            this.lblProcess.AutoSize = true;
            this.lblProcess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblProcess.Location = new System.Drawing.Point(20, 50);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(60, 15);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "Process:";
            // 
            // comboBoxProcesses
            // 
            this.comboBoxProcesses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxProcesses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.comboBoxProcesses.FormattingEnabled = true;
            this.comboBoxProcesses.Location = new System.Drawing.Point(90, 48);
            this.comboBoxProcesses.Name = "comboBoxProcesses";
            this.comboBoxProcesses.Size = new System.Drawing.Size(400, 23);
            this.comboBoxProcesses.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(500, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(90, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnInject
            // 
            this.btnInject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnInject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInject.ForeColor = System.Drawing.Color.White;
            this.btnInject.Location = new System.Drawing.Point(500, 108);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(90, 30);
            this.btnInject.TabIndex = 6;
            this.btnInject.Text = "Inject";
            this.btnInject.UseVisualStyleBackColor = false;
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(90, 78);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(400, 23);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.Location = new System.Drawing.Point(20, 80);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(50, 15);
            this.lblSearch.TabIndex = 8;
            this.lblSearch.Text = "Search:";
            // 
            // txtPid
            // 
            this.txtPid.Location = new System.Drawing.Point(90, 108);
            this.txtPid.Name = "txtPid";
            this.txtPid.Size = new System.Drawing.Size(100, 23);
            this.txtPid.TabIndex = 9;
            this.txtPid.Font = new System.Drawing.Font("Segoe UI", 9F);
            // 
            // lblPid
            // 
            this.lblPid.AutoSize = true;
            this.lblPid.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPid.Location = new System.Drawing.Point(20, 110);
            this.lblPid.Name = "lblPid";
            this.lblPid.Size = new System.Drawing.Size(35, 15);
            this.lblPid.TabIndex = 10;
            this.lblPid.Text = "PID:";
            // 
            // lblGitHub
            // 
            this.lblGitHub.AutoSize = true;
            this.lblGitHub.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblGitHub.Location = new System.Drawing.Point(450, 148);
            this.lblGitHub.Name = "lblGitHub";
            this.lblGitHub.Size = new System.Drawing.Size(140, 13);
            this.lblGitHub.TabIndex = 11;
            this.lblGitHub.Text = "https://github.com/backdoor831246";
            this.lblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblGitHub_LinkClicked);
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Italic);
            this.lblDeveloper.Location = new System.Drawing.Point(450, 163);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(90, 13);
            this.lblDeveloper.TabIndex = 12;
            this.lblDeveloper.Text = "developed by dev0Rot";
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.White;
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMain.Controls.Add(this.lblDllPath);
            this.panelMain.Controls.Add(this.txtDllPath);
            this.panelMain.Controls.Add(this.btnBrowse);
            this.panelMain.Controls.Add(this.lblProcess);
            this.panelMain.Controls.Add(this.comboBoxProcesses);
            this.panelMain.Controls.Add(this.btnRefresh);
            this.panelMain.Controls.Add(this.btnInject);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.lblSearch);
            this.panelMain.Controls.Add(this.txtPid);
            this.panelMain.Controls.Add(this.lblPid);
            this.panelMain.Controls.Add(this.lblGitHub);
            this.panelMain.Controls.Add(this.lblDeveloper);
            this.panelMain.Location = new System.Drawing.Point(10, 10);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(610, 190);
            this.panelMain.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(630, 210);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "dev0RotInjector";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblDllPath;
        private System.Windows.Forms.TextBox txtDllPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblProcess;
        private System.Windows.Forms.ComboBox comboBoxProcesses;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnInject;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtPid;
        private System.Windows.Forms.Label lblPid;
        private System.Windows.Forms.LinkLabel lblGitHub;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.Panel panelMain;
    }
}