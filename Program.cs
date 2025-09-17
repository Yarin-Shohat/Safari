using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Safari
{
    internal static class Program
    {
        // Import kernel32.dll function to open a console window
        [DllImport("kernel32.dll")]
        private static extern bool AllocConsole();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AllocConsole(); // ?? Open a real console window

            // Default WinForms config
            ApplicationConfiguration.Initialize();
            Application.Run(new WelcomeForm());
        }
    }
}

//namespace Safari
//{
//    internal static class Program
//    {
//        /// <summary>
//        ///  The main entry point for the application.
//        /// </summary>
//        [STAThread]
//        static void Main()
//        {
//            // To customize application configuration such as set high DPI settings or default font,
//            // see https://aka.ms/applicationconfiguration.
//            ApplicationConfiguration.Initialize();
//            Application.Run(new WelcomeForm());
//        }
//    }
//}
