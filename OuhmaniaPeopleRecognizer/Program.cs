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
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.GetCultureInfo("en-US");

            System.Threading.Thread.CurrentThread.CurrentUICulture =
                System.Globalization.CultureInfo.GetCultureInfo("en-US");
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName);
            // Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            // Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
