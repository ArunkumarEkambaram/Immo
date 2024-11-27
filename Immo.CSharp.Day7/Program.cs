using System;
using System.Data.SqlClient;


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

            //SimpleSingleton obj1 = SimpleSingleton.Instance;
            //SimpleSingleton obj2 = SimpleSingleton.Instance;
            //SimpleSingleton obj3 = SimpleSingleton.Instance;

            //Console.WriteLine(SimpleSingleton.Counter);

            //DbConnectionSingleton con1 = DbConnectionSingleton.Instance;
            //SqlConnection con = con1.GetConnection();
            //if (con.State == System.Data.ConnectionState.Closed)
            //{
            //    con.Open();
            //}
            //  con.Close();

            Employee_SRP obj = new Employee_SRP();
            obj.GetEmployee();
        }
    }
}

//Parent obj =new Child();