using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                var zero = 0;
                //Have to add a variable otherwise the DivideByZeroException
                //will be thrown at compile time.
                var a = 199/zero;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e);
            }
            finally 
            {
                Console.WriteLine("Finally Executed");
            }
        }
    }
}
