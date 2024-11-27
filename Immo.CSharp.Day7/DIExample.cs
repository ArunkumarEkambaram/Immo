using System;

namespace Immo.CSharp.Day7
{
    public interface ILogError
    {
        void LogError(string message);
    }

    public class LogErrorHandler
    {
        //  private LoginSQL _logSQL;
        private ILogError _logError;

        //Constructor Injection
        public LogErrorHandler(ILogError logError)
        {
            //_logSQL = new LoginSQL();
           // _logSQL = logSQL;
           //Initialize Interface
           _logError = logError;
        }

        public void DoWork(string err)
        {
            if (true)
            {
                _logError.LogError(err);
            }
        }
    }

    public class LoginSQL : ILogError
    {
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class LoginOracle : ILogError
    {
        public void LogError(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : ILogError
    {
        public void LogError(string message)
        {
            throw new NotImplementedException();
        }
    }
}
