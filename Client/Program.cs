using System;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static Client_window Client_window
        {
            get => default;
            set
            {
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Client_window());
        }
    }
}
