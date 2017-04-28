using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Implicit-Conversion
            int num = 32000;
            long bigNum = num;
            Console.WriteLine(bigNum);

            //Explicit-Conversion
            double x = 312.123;
            var a = (int) x;
            Console.WriteLine(a);
        }
    }
}
