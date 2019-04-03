using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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


    }
}
