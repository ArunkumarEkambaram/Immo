using System;

namespace Immo.CSharp.Day5
{
    //Step 1
    public delegate int DelegateCalculation(int a, int b);
    // public delegate int MyDelegate(int a, int b, int c);
    public delegate void MyDelegate();
    internal class DelegateExample
    {
        public int AddNumbers(int n1, int n2)
        {
            return n1 + n2;
        }

        public int MultiNumber(int n1, int n2)
        {
            return n1 * n2;
        }

        public string GetString(int n1, int n2)
        {

            return (n1 + n2).ToString();
        }

        public void Greet()
        {
            Console.WriteLine("Hello World!!!");
        }

        public void WelcomeUser()
        {
            Console.WriteLine("Hello, User");
        }
    }
}
