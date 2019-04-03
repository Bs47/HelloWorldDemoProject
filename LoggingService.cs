using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HelloWorldDemoProject
{
    public class LoggingService
    {
        private string _filename;

        public LoggingService()
        {
           // Init();
        }

        public void Init()
        {
            _filename = GetFilename();
        }

        /// <summary>
        /// Eintrag in die Logdatei schreiben
        /// </summary>
        /// <param name="text">einzelner einzutragender Text</param>
        public void Log (string text)
        {
            string file = GetFilename();
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(text);
            }
        }
        /// <summary>
        /// Einträge in die Logdatei schreiben
        /// </summary>
        /// <param name="lines">Liste</param>
        public void Log(List<string> lines)
        {
            string file = _filename;// GetFilename();
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                foreach (string item in lines)
                {
                    writer.WriteLine(item);
                }

            }
        }

        /// <summary>
        /// Eintrag in die Logdatei schreiben
        /// </summary>
        /// <param name="lines">Array von einzutrageneden Texten</param>
        public void Log(string[] lines)
        {
            string file = _filename;// GetFilename();
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                foreach (string item in lines)
                {
                    writer.WriteLine(item);
                }
                
            }
        }

        /// <summary>
        /// löscht die 1. Zeile aus der Log-Datei
        /// </summary>
        public void DeleteLog()
        {
            string file = _filename;// GetFilename();

            if(System.IO.File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);
                lines[0]=lines[0].Replace(lines[0], "");
                File.Delete(file);
                using (StreamWriter writer = new StreamWriter(file, true))
                {
                    foreach (string item in lines)
                    {
                        if (!String.IsNullOrEmpty(item)) { writer.WriteLine(item); }
                    }
                }
            }

        }
        /// <summary>
        /// ermitttelt den Namen der Logdatei
        /// </summary>
        /// <returns>Dateiname</returns>
        private string GetFilename()
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];
            string folder = Path.Combine(path, "Sage.Logs");
            System.IO.Directory.CreateDirectory(folder);

            return Path.Combine(path,"Sage.Logs", "logfile.txt");
        }

        
    }
}
