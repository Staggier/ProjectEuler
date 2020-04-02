// The Problem can be found here: https://projecteuler.net/problem=99
using System;

namespace PE099
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CompareLargeExponents());
            Console.ReadLine();
            return;
        }

        public static long CompareLargeExponents()
        {
            StreamReader sr = new StreamReader("p099_base_exp.txt");
            long line = 0, n = 1, a = 1, c = 1;

            for (string s = sr.ReadLine(), temp = ""; s != null; s = sr.ReadLine(), temp = "", c++)
            {
                long t1 = 0, t2 = 0;
                foreach (char ch in s)
                {
                    if (ch != ',')
                        temp += ch;
                    else
                    {
                        t1 = Convert.ToInt64(temp);
                        temp = "";
                    }                
                }
                t2 = Convert.ToInt32(temp);
               
                if (a * Math.Log(n) < t2 * Math.Log(t1))
                {
                    line = c;
                    n = t1;
                    a = t2;
                }
            }

            return line;
        }
    }
}