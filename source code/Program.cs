using System;
using System.Windows.Forms;

namespace dev0RotInjector
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string dllPath = args.Length > 0 ? args[0] : "";
            Application.Run(new Form1(dllPath));
        }
    }
}