using System.Collections.Generic;

namespace HelloWorldDemoProject
{
    public interface ILoggingService
    {
        void DeleteLog();
        void Log(List<string> lines);
        void Log(string text);
        void Log(string[] lines);
    }
}