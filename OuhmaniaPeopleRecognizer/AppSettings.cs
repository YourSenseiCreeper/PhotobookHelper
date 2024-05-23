using System;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace OuhmaniaPeopleRecognizer
{
    public class AppSettings<T> where T : new()
    {
        private static string DEFAULT_FILENAME = "settings.json";
        public static string DEFAULT_PATH = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\OuhmaniaPeopleRecognizer";
        public static string FULL_PATH = DEFAULT_PATH + "\\" + DEFAULT_FILENAME;
        public static void Save(T pSettings, string initialDirectory)
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*",
                InitialDirectory = initialDirectory
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var writer = new StreamWriter(saveFileDialog.OpenFile());
                writer.WriteLine(new JavaScriptSerializer().Serialize(pSettings));
                writer.Dispose();
                writer.Close();
            }
        }

        public static Tuple<bool, T> Load()
        {
            var t = new T();
            var success = false;
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*",
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var reader = new StreamReader(openFileDialog.OpenFile());
                t = new JavaScriptSerializer().Deserialize<T>(reader.ReadLine());
                reader.Dispose();
                reader.Close();
                success = true;
            }
            return new Tuple<bool, T>(success, t);
        }
    }
}
