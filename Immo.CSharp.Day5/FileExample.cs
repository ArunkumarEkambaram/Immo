using System;
using System.IO;
using System.Security.Policy;


namespace Immo.CSharp.Day5
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }

    internal class FileExample
    {
        private FileStream fs = null;
        private StreamWriter writer = null;
        private StreamReader reader = null;

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

        public void WriteText(string path)
        {
            try
            {
                var person = GetPerson();
                fs = new FileStream(path, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(fs);
                writer.WriteLine($"Person Id :{person.Id}");
                writer.WriteLine($"Person Name :{person.Name}");
                writer.WriteLine($"Person City :{person.City}");
                writer.Flush();//Clear Buffer memory
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                writer?.Close();
                fs?.Close();
            }
        }

        //Read from File
        public void ReadFromFile(string path)
        {                   
            fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            reader = new StreamReader(fs);
            if (reader != null)
            {
               // reader.BaseStream.Seek(3, SeekOrigin.Begin);
                Console.WriteLine(reader.ReadToEnd());
            }
            reader?.Close();
            fs?.Close();
        }
    }
}
