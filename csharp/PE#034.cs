// The problem can be found here https://projecteuler.net/problem=34
using System;

namespace PE034
{
    class Program
    {    

        static void Main(string[] args)
        {
            Console.WriteLine(DigitFactorials());
            Console.ReadLine();
            return;
        }

        public static int Factorial(int num)
        {
            int sum = 1;
            for (int i = 2; i <= num; i++)
                sum *= i;
            return sum;
        }

        public static bool FactorialSum(int num)
        {
            string str = num.ToString();
            int sum = 0;
            foreach (char c in str)
                sum += Factorial(Convert.ToInt32(c.ToString()));
            return num == sum;
        }

        public static int DigitFactorials()
        {
            int sum = 0, i = 3;
            while (i < Factorial(9))
                if (FactorialSum(i++))
                    sum += i - 1;
            
            return sum;
        }
    }
}