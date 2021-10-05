using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
	class series
	{
		public static void Main()
		{
			double x, sum, t, d;
			int i, n;



			Console.Write("Input  Value of x :");

			x = int.Parse(Console.ReadLine());
			Console.Write("Input the number of terms : ");
			n = Convert.ToInt32(Console.ReadLine());
			sum = 1; t = 1;
			for (i = 1; i < n; i++)
			{
				d = (2 * i) * (2 * i - 1);
				t = -t * x * x / d;
				sum = sum + t;
			}
			Console.Write("\noutput = {0}", sum);
		}
	}
}
