using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    static class Program
    {
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SW_HIDE = 0;
        const int SW_SHOW = 5;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            var handle = GetConsoleWindow();

            //Application.Run(new FormCalc());

            if (args.Length < 1)
            {
                ShowWindow(handle, SW_HIDE);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormCalc());
            }
            else
            {
                //use console instead
                ConsoleSolve.Solver solver = new ConsoleSolve.Solver(args);
            }
            //Console.WriteLine("GetCommandLineArgs: {0}", string.Join(", ", args));
        }
    }
}
