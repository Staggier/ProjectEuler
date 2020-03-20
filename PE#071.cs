// The Problem can be found here: https://projecteuler.net/problem=71
using System;

namespace PE071
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(PE071());
            Console.ReadLine();
            return;
        }

        public static int PE071()
        {
            return (1000000 / 7) * 3 - 1; 
        }
    }
}
