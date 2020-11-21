using System;
using System.Collections.Generic;
using System.Linq;

namespace DecToFrac
{
    class Program
    {
        public static int GCD(int a, int b)
        {
            while (a != b)
            {
                int k = Math.Abs(a - b);
                if (a > b)
                {
                    a = k;
                }
                else if (b > a)
                {
                    b = k;
                }
            }
            return a;
        }

        public static int CountZeroInString(string fraction)
        {
            int counter = 0;
            int startIndex = fraction.IndexOf('.');
            for (int i = startIndex; i < fraction.Length; i++)
            {
                if(fraction[i] == '0')
                {
                    counter++;
                }
            }
            return counter;
        }

        public static string FindPeriod(string fraction)
        {
            int startIndex = fraction.IndexOf('.');
            string period = "";
            for(int i = startIndex+1; true; i++)
            {
                int k = period.IndexOf((fraction[i]));
                if(k != -1)
                {
                    return period;
                }
                else if(k == -1)
                {
                    period += fraction[i];
                }
            }
        }

        public static void Main()
        {
            string fraction = Console.ReadLine();
            double dFraction = Convert.ToDouble(fraction);
            string period = FindPeriod(fraction);
            /*Console.Write("Period: ");
            Console.Write(period);*/
            double xFraction = dFraction * Math.Pow(10, period.Length);

            int countZero = CountZeroInString(fraction);
            if (countZero == 1)
            {
                period = period.Remove(0, 1);
            }

            int num = Convert.ToInt32(xFraction - dFraction);
            int den = Convert.ToInt32(Math.Pow(10, period.Length)) - 1;
            /*Console.WriteLine(num);
            Console.WriteLine(den);*/
            int gcd = GCD(num, den);
            num = num / gcd;
            den = den / gcd;
            Console.Write(num);
            Console.Write('/');
            Console.Write(den);
        }
    }
}
