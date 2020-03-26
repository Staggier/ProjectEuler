// The Problem can be found here: https://projecteuler.net/problem=7

using System;
using System.Collections.Generic;
namespace PE007
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE007());
            Console.ReadLine();
            return;
        }

        public static int PE007()
        {
            return PrimeSieve((int)Math.Pow(10, 6))[10000];
        }

        public static List<int> PrimeSieve(int n)
        {
            List<int> primes = new List<int>() { 2 };
            bool[] arr = new bool[n + 1];

            for (int i = 0; i < n; i++)
                arr[i] = true;

            for (int i = 2; i * i <= n; i++)
                if (arr[i] == true)
                    for (int j = i * i; j <= n; j += i)
                        arr[j] = false;

            for (int i = 3; i <= n; i += 2)
                if (arr[i])
                    primes.Add(i);

            return primes;
        }
    }
}