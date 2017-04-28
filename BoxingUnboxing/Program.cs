using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int i = 223;
            // Boxing
            object o = i;
            Console.WriteLine(o);
            // Unboxing
            o = 256;
            i = (int) o;
            Console.WriteLine(i);

        }
    }
}
