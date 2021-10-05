using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    abstract class Emp
    {
        public abstract int sal();
    }
    class Temp : Emp
    {
        public int amt { get; set; }
            public Temp()
        {

        }
        public Temp(int  amt)
        {
            this.amt = amt;
        }
        public override int sal()
        {
           
            return  12 * amt;
            

        }

    }
    class Pemp:Emp
    {
        public int amt { get; set; }
        public override int sal()
        {
             return (12 * amt) + 1000;
            
            
        }
    }
    class Prog
    {
        public static void Main()
        {
            Emp e1 = new Temp(10000);
            Console.WriteLine(e1.sal());   
            Pemp p1 = new Pemp();
            p1.amt = 30000;
            Console.WriteLine(p1.sal());
            

        }
    }
}
