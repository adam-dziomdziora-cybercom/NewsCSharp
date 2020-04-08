using System;

namespace NewsCSharp.LoggerWrapper
{
    public class Logger : ILogger
    {
        public void Write(string message, params object[] args) => Console.WriteLine(message, args);


        public void WriteOldWay(string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }
    }
}