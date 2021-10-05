using System;
//abstract
namespace ConsoleApp1
{
    abstract class stringprog
    {
        public abstract void Cal(int a);

    }
    class ts : stringprog
    {
        public override void Cal(int a)
        {
            Console.WriteLine(a * 10);
        }
    }

    class ps : stringprog
    {
        public override void Cal(int a)
        {
            Console.WriteLine(a * 12);
            string s = Console.ReadLine();
            string k = " ";
            if (s.IndexOf('j') == 0 && s.IndexOf('b') == 1)
            {
                Console.WriteLine(s);
            }
            else if (s.IndexOf('j') == 0)
            {
                k = "j";
                k += s.Substring(2, s.Length - 2);
                Console.WriteLine(k);
            }
            else if (s.IndexOf('b') == 1)
            {
                k += s.Substring(1, s.Length - 1);
                Console.WriteLine(k);
            }
            else
            {
                Console.WriteLine(s.Substring(2, s.Length - 2));
            }

        }
    }

    class Prog2
    {
        static void Main()
        {
            stringprog e = new ts();
            e.Cal(10);
            ts t = new ts();
            t.Cal(9);
            ps p = new ps();
            p.Cal(8);
        }
    }
}