using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var newTest = new Test();
            newTest.TestMethod();
            newTest.TestMethod("sample params");
        }
    }

    public class Test
    {
        public void TestMethod()
        {
            Console.WriteLine("Test Method without parameters");
        }

        public void TestMethod(string param)
        {
            Console.WriteLine($"Test method with parameters -> {param}");
        }
    }
}
