using System;
using System.Collections.Generic;
using System.IO;
using System.Security.AccessControl;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";
            saveFileDialog.InitialDirectory = initialDirectory;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog.OpenFile());
                writer.WriteLine(new JavaScriptSerializer().Serialize(pSettings));
                writer.Dispose();
                writer.Close();
            }
        }

        public static Tuple<bool, T> Load()
        {
            T t = new T();
            bool success = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog.OpenFile());
                t = new JavaScriptSerializer().Deserialize<T>(reader.ReadLine());
                reader.Dispose();
                reader.Close();
                success = true;
            }
            return new Tuple<bool, T>(success, t);
        }
    }
}
