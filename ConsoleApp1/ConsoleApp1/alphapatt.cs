using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class alphapatt
    {
        static void Main()
        {
            int i = 65;
            for (int x = 0; x < 5; x++)
            {
                for (int y = 1; y <= 5 - x; y++)
                {
                    Console.Write(" ");
                }
                int a = i + 1;
                while (i > 64)
                {
                    Console.Write(Convert.ToChar(i));
                    i--;
                }
                i++;
                while (i < a - 1)
                {
                    i++;
                    Console.Write(Convert.ToChar(i));
                }
                Console.WriteLine();
                i++;
            }
        }
    }
}
