using System;
using System.IO;


namespace Immo.CSharp.Day7
{
    internal class ExceptionHandler
    {
        public static void LogError(Exception ex)
        {
            string error = $"Error occurred on {DateTime.Now}\nError Message :{ex.Message}\nStack Trace :{ex.StackTrace}";            
            File.AppendAllText("ErrorLog.txt", error);

        }
    }
}
