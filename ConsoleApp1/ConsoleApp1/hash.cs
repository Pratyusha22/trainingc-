using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ConsoleApp1
{
    class hash
    {
        public static void Main()
        {
            //Hashtable ht = new Hashtable();
            //int[] arr = new int[] { 2, 5, 6, 8 };
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    ht.Add(arr[i], arr[i] * arr[i]);
            //}
            //foreach (object i in ht.Keys)
            //{
            //    Console.WriteLine(i + " " + ht[i]);
            //}
            //Queue<int> q = new Queue<int>();
            //q.Enqueue(1);
            //q.Enqueue(2);
            //q.Enqueue(3);
            //q.Enqueue(4);
            //foreach(int i in q)

            //{
            //    Console.WriteLine(i);
            //}
            //Stack<int> s = new Stack<int>();
            //s.Push(5);
            //s.Push(6);
            //s.Push(7);
            //s.Push(8);
            //foreach(int j in s)
            //{
            //    Console.WriteLine(j);
            //}
            //Dictionary<int, string> d = new Dictionary<int, string>();
            //d.Add(1, "red");
            //d.Add(2, "blue");
            //d.Add(3, "redbull");
            //foreach(int k in d.Keys)
            //{
            //    Console.WriteLine(d[i]);
            //}
            int[] no = new int[] { 1, 1, 3, 2, 1, 1, 2, 3, 4, 5, 2, 2, 2, 3 };
            Dictionary<int, int> d1 = new Dictionary<int, int>();
            foreach(int m in no)
            {
                if(d1.ContainsKey(m))
                {
                    d1[m] += 1;
                }
                else
                {
                    d1[m] = 1;
                }
            }
            foreach(int m in d1.Keys)
            {
                Console.WriteLine(d1[m]);
            }



        }

    }

}


   
