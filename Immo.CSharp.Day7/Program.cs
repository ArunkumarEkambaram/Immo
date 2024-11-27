using System;


namespace Immo.CSharp.Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginSQL sql=new LoginSQL();
            LoginOracle oracle=new LoginOracle();
            FileLogger logger=new FileLogger();
            LogErrorHandler logErrorHandler = new LogErrorHandler(sql);
            logErrorHandler.DoWork("Runtime Error");
        }
    }
}

//Parent obj =new Child();