using System;
using System.Collections.Generic;
using System.Text;

namespace ltitraining
{
    class First
    {
        static void Main()
        {
            int a = 10;
            int b = 20;
            
            char c = char.Parse(Console.ReadLine());
            switch(c)
            {
                case '+':Console.WriteLine(a + b);
                         break;
                case '-':Console.WriteLine(a - b);
                         break;
                case '*':Console.WriteLine(a * b);
                         break;
                case '/':Console.WriteLine(a / b);break;

            }

          
        }
    }
}
