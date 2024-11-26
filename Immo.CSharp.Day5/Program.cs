using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;

namespace Immo.CSharp.Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region MyRegion1
            //FileExample example = new FileExample();
            ////example.WriteText(@"D:\2024\Immo Capital\Person.txt");
            //example.ReadFromFile(@"D:\2024\Immo Capital\Person.txt");            

            //Example2 ex2 = new Example2();
            //string path = @"D:\2024\Immo Capital\Example2.txt";
            ////ex2.WriteText("Example2.txt");
            ////var result= ex2.ReadText(path);
            //// Console.WriteLine(result);

            //if (File.Exists("Example2.txt"))
            //{
            //    File.Delete("Example2.txt");
            //    Console.WriteLine("File Deleted!");
            //}

            //BinaryExample obj=new BinaryExample();
            ////obj.WriteBinary("Binary.txt");
            //obj.ReadBinary("Binary.txt");
            #endregion

            #region MyRegion2
            //DelegateExample obj = new DelegateExample();

            ////Step 2
            //DelegateCalculation del1 = obj.AddNumbers;

            //DelegateCalculation del2 = obj.MultiNumber;
            ////DelegateCalculation del3 = new DelegateCalculation(obj.MultiNumber);

            ////Step 3
            //var result = del1(50, 5);
            //var result2 = del2(5, 6);
            //Console.WriteLine($"Output :{result}");

            //  MyDelegate del2 = obj.Greet;
            //  del2 += obj.WelcomeUser;

            ////  del2 -= obj.Greet;

            //  del2();

            ////Anonymous Method
            //DelegateCalculation objDivide = delegate (int a, int b)
            //{
            //    return a / b;
            //};
            //Console.WriteLine($"Divide :{objDivide(50, 4)}");

            ////Anonymous Function using Lambda 
            //DelegateCalculation objAdd = (a, b) =>
            //{
            //    return a + b;
            //};
            #endregion

            #region MyRegion3
            //Anonymous Method using Action, Func
            //Action - Does not return value
            //PreDefinedDelegate obj = new PreDefinedDelegate();
            //Action<int, string> callGetData = obj.GetData;
            //callGetData(1001, "Praveen");

            //Func
            //Func<Person> objPerson = obj.GetPerson;
            //var result = objPerson();
            //Console.WriteLine($"Id :{result.Id}\tName :{result.Name}");

            //Func<int, int, string> objAdd = obj.AddNumber;
            //string result = objAdd(50, 60);
            //Console.WriteLine(result);

            //Action<int, string> obj1 = (id, name) =>
            //{
            //    Console.WriteLine($"Id :{id}\tYour Name :{name}");
            //};

            //obj1(5001, "Kayal");

            //Func<string, string, bool> fun1 = (name, city) =>
            //{
            //    bool isValid = true;
            //    Console.WriteLine("Name :" + name);
            //    Console.WriteLine("City :" + city);
            //    return isValid;
            //};

            //var res = fun1("Abc", "Xyz");
            //Console.WriteLine(res);
            #endregion

            #region MyRegion4
            //Me meObj = new Me();
            //MyFriend friend1 = new MyFriend();
            //meObj.OnNotification += new Notify(friend1.Like);
            //MyFriend friend2 = new MyFriend();
            //meObj.OnNotification += friend2.Like;

            //meObj.GetNotification();
            //Console.WriteLine($"Total Likes :{Me.TotalLikes}");
            #endregion

            #region MyRegion5
            //GenericExample obj = new GenericExample();
            //obj.NonGeneric();

            // var person = obj.AddPerson();

            //foreach (var item in person)
            //{
            //    Console.WriteLine($"Id :{item.Id}\tName :{item.Name}");
            //}

            ////Dictionary
            //Dictionary<int, Person> d1 = new Dictionary<int, Person>();
            //d1.Add(1, new Person { Id = 1, Name = "Jagan", City = "Chennai" });
            //d1.Add(2, new Person { Id = 2, Name = "Babu", City = "Bengaluru" });

            //var res = person.Where(x => x.City == "Chennai").ToList();

            //foreach (var item in res)
            //{
            //    Console.WriteLine($"Id :{item.Id}\tName :{item.Name}");
            //}

            //MyList<int> myList=new MyList<int>();
            //foreach(var item in myList)
            //{
            //    Console.WriteLine(item);
            //}
            #endregion

            ThreadExample obj = new ThreadExample();

            Thread t1 = new Thread(new ThreadStart(obj.GetData1));
            Thread t2 = new Thread(new ThreadStart(obj.GetData2));

            t1.Start();
            t1.Join();
            t2.Start();

  
            t2.Join();
            
            // AsyncOperation1 obj1 = new AsyncOperation1();
            // obj1.GetData1();
            //await obj1.GetData2();
        }
    }
}
