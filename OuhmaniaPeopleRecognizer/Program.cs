using System;
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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainWindow());
            }
            catch (Exception ex)
            {
                // dodać logowanie błędu
                Application.Run(new ErrorDialog(ex));
            }
        }
    }
}
