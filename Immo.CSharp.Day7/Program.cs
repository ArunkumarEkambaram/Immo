using System;


namespace Immo.CSharp.Day7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LoginSQL sql=new LoginSQL();
            //LoginOracle oracle=new LoginOracle();
            //FileLogger logger=new FileLogger();
            //LogErrorHandler logErrorHandler = new LogErrorHandler(sql);
            //logErrorHandler.DoWork("Runtime Error");

            SimpleSingleton obj1 = SimpleSingleton.Instance;
            SimpleSingleton obj2 = SimpleSingleton.Instance;
            SimpleSingleton obj3 = SimpleSingleton.Instance;

            Console.WriteLine(SimpleSingleton.Counter);
        }
    }
}

//Parent obj =new Child();