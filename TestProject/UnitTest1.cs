using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LoggerTestProject
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void ctor_Test()
        {
            var logger = new HelloWorldDemoProject.LoggingService(); logger.Init();
            Assert.IsNotNull(logger);
        }

        [TestMethod]
        public void AppendLineToLog()
        {
            var path = @"C:\Users\ADM\AppData\Roaming\Sage.Logs\logfile.txt";
            if (System.IO.File.Exists(path)) { System.IO.File.Delete(path); }

            new HelloWorldDemoProject.LoggingService().Log("testeintrag: 777 " + DateTime.Now.ToString());
            using (System.IO.StreamReader reader = new System.IO.StreamReader(@"C:\Users\ADM\AppData\Roaming\Sage.Logs\logfile.txt"))
            {
                string logContent = reader.ReadToEnd();
                Assert.IsTrue(logContent.Contains("777"), "Eintrag in Logdatei nicht vorhanden");
            }
        }

        [TestMethod]
        public void DeleteLineFromLog()
        {
            HelloWorldDemoProject.LoggingService logger = new HelloWorldDemoProject.LoggingService();
            logger.Init();
            logger.DeleteLog();
        }

        [TestMethod]
        public void TestLogLineModel()
        {
            var path = @"C:\Users\ADM\AppData\Roaming\Sage.Logs\logfile.txt";
            int _index = 0;
            HelloWorldDemoProject.LoggingService logger = new HelloWorldDemoProject.LoggingService();
            logger.Init();

            ClearTestFile();

            for (int i = 0; i < 100; i++)
            {
                _index++;
                SharedTypes.LogLineModel model = new SharedTypes.LogLineModel() { RowIndex = i, LoggingTime = DateTime.Now, Message = "Testeintrag " + i.ToString() };
                logger.Log(model);
                System.Threading.Thread.Sleep(100);
            }

            var list = new List<String>();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(path))
            {
                while(!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    list.Add(line);
                }
            }
            var erg1 = list.Where(p => p.StartsWith("0")).Count();
            var erg2 = list.Where(p => p.StartsWith("99")).Count();
            var erg3 = list.Count();

            Assert.IsTrue(erg1 == 1 && erg2 ==1 && erg3 == 100);

        }

        private void ClearTestFile()
        {
            var path = @"C:\Users\ADM\AppData\Roaming\Sage.Logs\logfile.txt";
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(path))
            {
                writer.Write("");
            }
        }

    }
}
