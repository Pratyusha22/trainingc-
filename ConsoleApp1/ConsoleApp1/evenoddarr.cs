using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class evenoddarr
    {
        static void Main()
        {
            int[] arr = { 4, 5, 3, 2, 1, 6, 8 };
            int j = arr.Length - 1;
            int i = 0;
            while (i < j)
            {
                while (arr[i] % 2 == 0)
                    i++;
                while (arr[j] % 2 != 0)
                    j--;
                if (i < j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                }
            }
            for (int x = 0; x < arr.Length; x++)
                Console.Write(arr[x]);
        }
    }
}
