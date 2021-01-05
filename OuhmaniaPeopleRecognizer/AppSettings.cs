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
            // var directoryPath = savePath.Substring(0, savePath.LastIndexOf("\\"));
            // if (!Directory.Exists(directoryPath))
            //     Directory.CreateDirectory(directoryPath);
            //
            // if (!File.Exists(savePath))
            //     File.Create(savePath);

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "Ouhmania reco files (*.opr)|*.opr|All files (*.*)|*.*";
            saveFileDialog1.InitialDirectory = initialDirectory;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
                writer.WriteLine(new JavaScriptSerializer().Serialize(pSettings));
                writer.Dispose();
                writer.Close();
            }
        }

        public static T Load(string loadPath)
        {
            T t = new T();
            if (File.Exists(loadPath))
                t = new JavaScriptSerializer().Deserialize<T>(File.ReadAllText(loadPath));
            return t;
        }
    }
}
