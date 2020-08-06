// The Problem can be found here: https://projecteuler.net/problem=87
using System;
using System.Linq;
using System.Collections.Generic;

namespace PE087
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PrimePowerTriples());
            Console.ReadLine();
            return;
        }

        public static int PrimePowerTriples()
        {
            List<int> primes = new List<int>() { 2 };
            int c = 3, p = 1;
            while (c < Math.Sqrt(50000000))
            {
                if (IsPrime(c))
                {
                    primes.Add(c);
                    p++;

                }
                c += 2;
            }

            Dictionary<double, int> d = new Dictionary<double, int>();
            int counter = 0;
            for (int i = 0; i < p; i++)
                for (int j = 0; j < p; j++)
                    for (int k = 0; k < p; k++)
                    {
                        double temp = Math.Pow(primes[i], 2) + Math.Pow(primes[j], 3) + Math.Pow(primes[k], 4);
                        if (!d.ContainsKey(temp) && temp < 50000000)
                        {
                            d.Add(temp, 0);
                            counter++;
                        }
                        else if (temp > 50000000)
                            break;
                    }

            return counter;
        }
    }
}