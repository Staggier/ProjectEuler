// This Problem can be found here: https://projecteuler.net/problem=72
using System;

namespace PE072
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE072());
            Console.ReadLine();
            return;
        }

        public static double PE072()
        {
            double ans = 0;
            for (long i = 2; i <= 1000000; i++)
                ans += Phi(i);
            return ans;
        }

        static double Phi(long n)
        {
            double ans = n;
            for (long i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                {
                    while (n % i == 0)
                        n /= i;
                    ans *= 1.0 - (1.0 / i);
                }
            }
            if (n > 1)
                ans *= 1.0 - (1.0 / n);
            return ans;
        }
    }
}