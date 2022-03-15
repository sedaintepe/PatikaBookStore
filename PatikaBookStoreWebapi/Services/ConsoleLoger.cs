using System;

namespace PatikaBookStoreWebapi.Services
{
    public class ConsoleLoger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[ConsoleLogger] -" + message);
        }
    }
}