using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
