using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var derivedClass = new Derived();
            derivedClass.OverrideThis();
        }
    }

    public class Base
    {
        public virtual void OverrideThis()
        {
            Console.WriteLine("Base Class Method Called");
        }
    }

    public class Derived : Base
    {
        public override void OverrideThis()
        {            
            Console.WriteLine("Derived Class Method Called");
            base.OverrideThis();
        }
    }
}
