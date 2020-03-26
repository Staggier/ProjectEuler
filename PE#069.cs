using System;
using System.Collections.Generic;
using System.Linq;

namespace PE069
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE069());
            Console.ReadLine();
            return;
        }

        public static int PE069()
        {
            List<int> primes = new List<int>() { 2 };
            for (int i = 3; primes.Aggregate((total, x) => total * x) < 1000000; i += 2)
                if (IsPrime(i))
                    primes.Add(i);

            primes.RemoveAt(primes.Count - 1);
            return primes.Aggregate((total, x) => total * x);
        }

        public static bool IsPrime(int n)
        {
            for (int i = 3; i <= Math.Sqrt(n) + 1; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}
