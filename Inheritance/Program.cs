using System;
using System.Collections.Generic;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var bases = new List<Base>();
            bases.Add(new Derived1());
            bases.Add(new Derived2());

            foreach (var item in bases)
            {
                item.Act();
            }
        }
    }

    public class Base 
    {
        public virtual void Act() {}
    }

    public class Derived1 : Base 
    {
        public override void Act()
        {
            Console.WriteLine("Act executed from Derived Class 1");
        }
    }

    public class Derived2 : Base
    {
        public override void Act()
        {
            Console.WriteLine("Act executed from Derived Class 2");
        }
    }
}
