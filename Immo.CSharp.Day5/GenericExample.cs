using System;
using System.Collections;
using System.Collections.Generic;

namespace Immo.CSharp.Day5
{

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class GenericExample
    {
        public void NonGeneric()
        {
            //Collection Initializer
            ArrayList list = new ArrayList()
            {
                1,2,4,"ABC","SSS",true,false, 500.5f
            };
            //Object Initializer
            Person p = new Person { Id = 101, Name = "Vinoth", City = "Mumbai" };
            list.Add(p);

            foreach (object o1 in list)
            {
                Console.WriteLine(o1);
                if (o1 is Person)
                {
                    //  var p1 = (Customer)o1;
                    var p1 = o1 as Customer;
                    Console.WriteLine($"Id :{p1?.Name}");
                }
            }
        }

        //public void AddPerson(Person p)
        //{
        //    List<Person> list = new List<Person>() { p };
        //}
        public List<Person> AddPerson()
        {
            List<Person> list = new List<Person>
            {
                new Person { Id = 1, Name = "Jagan", City = "Chennai" },
                new Person { Id = 2, Name = "Babu", City = "Bengaluru" },
                new Person { Id = 3, Name = "SAnjay", City = "Chennai" },
            };

            //List<Person> p1 = new List<Person>
            //{
            //    new Person { Id = 2, Name="sdfsdf", City="Chennai" };
            //};
            return list;
        }
    }

    public class MyList<T> : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
        }
    }
}
