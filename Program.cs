using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace WS
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += ThreadEx;
            Application.Run(new WebhookSender());
        }
        private static void ThreadEx(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            if (MessageBox.Show($"Exception message: {ex.Message}\n\nStack trace: {ex.StackTrace}\n\nSource: {ex.Source}\n\nInner Exception: {ex.InnerException}\n\nTarget Method: {ex.TargetSite}", ex.GetType().FullName, MessageBoxButtons.OKCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly) == DialogResult.Cancel)
                Application.Exit(new CancelEventArgs(true));
        }
    }
}
