//The Problem can be found here: https://projecteuler.net/problem=12

using System;
namespace PE012
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(PE012());
            Console.ReadLine();
            return;
        }

        public static int PE012()
        {
            int ans = 1;
            while (NumDivisors(TriangleNumber(ans)) < 500)
                ans++;

            return TriangleNumber(ans);
        }
        public static int TriangleNumber(int n)
        {
            return n * (n + 1) / 2;
        }

        public static int NumDivisors(int n)
        {
            int divs = 0;
            for (int i = 1; i <= Math.Sqrt(n) + 1; i++)
                if (n % i == 0)
                    divs++;
            
            return divs * 2 - 1;
        }
        // For any integer n, half plus one of its divisors are found before its root.
    }
}