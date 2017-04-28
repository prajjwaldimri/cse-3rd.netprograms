using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var exampleClass1 = new ExampleClass("Test");
            Console.WriteLine(exampleClass1.IsInitialized);
            Console.WriteLine(exampleClass1.ExampleString);
            
            var exampleClass2 = new ExampleClass(exampleClass1);
            exampleClass2.IsInitialized = false;            
            Console.WriteLine(exampleClass2.IsInitialized);
            Console.WriteLine(exampleClass2.ExampleString);
        }
    }

    public class ExampleClass
    {
        public bool IsInitialized;
        public string ExampleString;        

        //Constructor with parameter (Default)
        public ExampleClass(string anyString) 
        {
            IsInitialized = true;
            ExampleString = anyString;
        }

        //Copy-Constructor
        public ExampleClass(ExampleClass previousClass) 
        {
            IsInitialized = previousClass.IsInitialized;
            ExampleString = previousClass.ExampleString;
        }
    }
}
