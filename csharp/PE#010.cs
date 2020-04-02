//The Problem can be found here: https://projecteuler.net/problem=10

using System;
using System.Collections.Generic;
using System.Linq;

namespace PE010
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE010());
            Console.ReadLine();
            return;
        }

        public static long PE010()
        {
            return PrimeSieve((long)Math.Pow(10, 6) * 2).Sum();
        }

        public static List<long> PrimeSieve(long n)
        {
            List<long> primes = new List<long>() { 2 };
            bool[] arr = new bool[n + 1];

            for (int i = 0; i < n; i++)
                arr[i] = true;

            for (int i = 2; i * i <= n; i++)
                if (arr[i] == true)
                    for (int j = i * i; j <= n; j += i)
                        arr[j] = false;

            for (long i = 3; i <= n; i++)
                if (arr[(int)i])
                    primes.Add(i);

            return primes;
        }
    }
}