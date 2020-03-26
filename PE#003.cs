// The Problem can be found here: https://projecteuler.net/problem=3

using System;
using System.Collections.Generic;

namespace PE003
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE003());
            Console.ReadLine();
            return;
        }

        public static long PE003()
        {
            List<long> primes = PrimeSieve((long)Math.Pow(10, 6));
            long n = 600851475143, iter = 0, ans = 0;

            for (; primes[(int)iter] <= Math.Sqrt(n) + 1; iter++)
                if (n % primes[(int)iter] == 0)
                    ans = primes[(int)iter];

            return ans;
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

            for (int i = 3; i <= n; i += 2)
                if (arr[i])
                    primes.Add(i);

            return primes;
        }
    }
}