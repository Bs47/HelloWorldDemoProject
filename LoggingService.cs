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
        public LoggingService()
        {
        }
        /// <summary>
        /// Eintrag in die Logdatei schreiben
        /// </summary>
        /// <param name="text"></param>
        public void Log (string text)
        {
            var path = (string)Environment.GetEnvironmentVariables()["APPDATA"];

            string folder = Path.Combine(path, "Sage.Logs");
            System.IO.Directory.CreateDirectory(folder);
            string file = Path.Combine(folder, "logfile.txt");
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                writer.WriteLine(text);
            }
        }

        
    }
}
