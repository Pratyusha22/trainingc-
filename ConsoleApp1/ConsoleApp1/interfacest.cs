using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    interface interfacest
    {
        void show();
    }
    class Student : interfacest
    {
        public void show()
        {
            Console.WriteLine("hello");

        }
    }
    class prog1
    {
        public static void Main()
        {
            Student s1 = new Student();
            interfacest s2 = new Student();

        }
    }
}
