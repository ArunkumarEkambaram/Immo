using System;

namespace Immo.CSharp.Day5
{
    internal class PreDefinedDelegate
    {
        public void GetData(int id, string name)
        {
            Console.WriteLine($"Your Id :{id}\nYour Name :{name}");
        }

        public Person GetPerson()
        {
            Person person = new Person();
            Console.WriteLine("Enter Id :");
            person.Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name :");
            person.Name = Console.ReadLine();
            Console.WriteLine("Enter City :");
            person.City = Console.ReadLine();
            return person;
        }

        public string AddNumber(int n1, int n2)
        {
            return $"Addition :{n1 + n2}";
        }
    }
}
