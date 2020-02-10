// The Problem can be found here: https://projecteuler.net/problem=95

using System;
using System.Linq;
using System.Collections.Generic;

namespace PE095
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(AmicableChains());
            Console.ReadLine();
            return;
        }

        public static int AmicableChains()
        {
            Dictionary<int, int> d = new Dictionary<int, int>();
            int ans = 0, longest = 0;

            for (int i = 1; i < 1000000; i++)
            {
                if (d.ContainsKey(i))
                    continue;

                int temp = SumDivisors(i), count = 1;
                List<int> lst = new List<int>() { i };

                while (!lst.Contains(temp) && temp < 1000000)
                {
                    lst.Add(temp);
                    temp = SumDivisors(temp);
                    count++;
                }

                if (temp < 1000000)
                {
                    int len = Array.IndexOf(lst.ToArray(), temp);
                    for (int j = len, c = j; j < count; j++)
                        if (!d.ContainsKey(lst[j]))
                            d.Add(lst[j], count - c);
                        else
                            break;

                    for (int j = 0; j < len; j++)
                        if (!d.ContainsKey(lst[j]))
                            d.Add(lst[j], 0);
                        else
                            break;

                    if (count - len > longest)
                    {
                        for (int j = len, k = 1000000; j < count; j++)
                            if (k > lst[j])
                                ans = k = lst[j];
                        longest = count - len;
                    }
                }
                else
                    for (int j = 0; j < count; j++)
                        if (!d.ContainsKey(lst[j]))
                            d.Add(lst[j], 0);
                        else
                            break;
            }
            return ans;
        }
    }
}