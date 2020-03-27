//The Problem can be found here: https://projecteuler.net/problem=27

using System;
using System.Collections.Generic;
using System.Linq;

namespace PE027
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE027());
            Console.ReadLine();
            return;
        }

        public static int PE027()
        {
            HashSet<long> hash = PrimeSieve((long)Math.Pow(10, 4)).ToHashSet();
            int count = 0, highest = 0, A = 0, B = 0;

            for (int a = -999; a <= 999; a++)
                for (int b = -1000; b <= 1000; b++)
                {
                    count = 0;
                    for (int n = 0; ; n++)
                    {
                        if (hash.Contains(n * n + (a * n) + (b)))
                            count++;
                        else
                            break;
                    }
                    if (count > highest)
                    {
                        A = a;
                        B = b;
                        highest = count;
                    }
                }
            return A * B;
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