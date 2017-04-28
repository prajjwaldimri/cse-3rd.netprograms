using System;

namespace ConsoleApplication
{

    interface ITest 
    {
        void Print();
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            ITest test = new Test();
            test.Print();
        }
    }

    public class Test : ITest
    {
        public void Print()
        {
            Console.WriteLine("Printed");
        }
    }
}
