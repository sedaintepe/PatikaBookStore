using System;

namespace PatikaBookStoreWebapi.Services
{
    public class DbLogger : ILoggerServices
    {
        public void Write(string message)
        {
            Console.WriteLine("[DBLogger] -" + message);
        }
    }
}