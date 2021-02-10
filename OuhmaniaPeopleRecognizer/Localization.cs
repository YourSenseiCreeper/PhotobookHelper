using System;
using System.Globalization;
using System.Resources;
using System.Threading;

[assembly: NeutralResourcesLanguage("en-US")]

namespace OuhmaniaPeopleRecognizer
{
    public class Localization
    {
        private static ResourceManager _manager;

        public Localization()
        {
            string[] cultures = { "en-US", "pl-PL" };
            Random rnd = new Random();
            int cultureNdx = rnd.Next(0, cultures.Length);
            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                var newCulture = new CultureInfo(cultures[cultureNdx]);
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
                _manager = new ResourceManager($"MainWindow.{newCulture.Name.ToLower()}", typeof(MainWindow).Assembly);
                Console.WriteLine($"The current culture is {Thread.CurrentThread.CurrentUICulture.Name}. {_manager.GetString("HelloString")}");
            }
            catch (CultureNotFoundException e)
            {
                Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }
        }

        public static string Get(string name)
        {
            return _manager.GetString(name);
        }
    }
}
