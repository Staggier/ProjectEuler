// The Problem can be found here: https://projecteuler.net/problem=74
using System;
using System.Linq;
using System.Collections.Generic;

namespace PE074
{        
    class Program
    { 
        static void Main(string[] args)
        {
            Console.WriteLine(DFChain());
            Console.ReadLine();
            return;
        }

        public static int Factorial(int n)
        {
            int ans = 1;
            for (int i = n; i >= 2; i--)
                ans *= i;
            return ans;
        }
        
        public static int DigitFactorial(int n)
        {
            int ans = 0;
            string s = n.ToString();
            foreach (char c in s)
                ans += Factorial(Convert.ToInt32(c.ToString()));
            return ans;
        }

        public static int DFChain()
        {
            Dictionary<int, int> chains = new Dictionary<int, int>();
            List<int> lst = new List<int>();
            int val = 0, ans = 0, len = 0;

            for (int i = 1; i < 1000000; i++, val = i, len = 0, lst = new List<int>())
            {
                while (!lst.Contains(val))
                {
                    lst.Add(val);

                    if (chains.ContainsKey(val))
                        if (lst.Count == 60)
                            ans++;

                    val = DigitFactorial(val);
                    len++;
                }

                for (int j = len - 1; j < lst.Count; j++)
                    if (!chains.ContainsKey(lst[j]))
                        chains.Add(lst[j], 0);

                if (lst.Count - len - 1 == 60)
                    ans++;
            }
            return ans;
        }
    }
}