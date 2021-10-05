using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Dpatt
    {
        static void Main()
        {
            for(int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (i == 0 || i == 3)
                    {
                        if (j == 3)
                            Console.Write(" ");
                        else
                            Console.Write("*");
                    }
                    else if (j == 0 || j == 3)
                        Console.Write("*");
                    else
                        Console.Write(" ");
                }
                Console.WriteLine();
            }
        }
    }
}
