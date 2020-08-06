//The Problem can be found here: https://projecteuler.net/problem=59
using System;
using System.Linq;
using System.Collections.Generic;

namespace PE059
{
    public static class EnumerableExtensions
    {
        // Source: http://stackoverflow.com/questions/774457/combination-generator-in-linq#12012418
        private static IEnumerable<TSource> Prepend<TSource>(this IEnumerable<TSource> source, TSource item)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            yield return item;

            foreach (var element in source)
                yield return element;
        }

        public static IEnumerable<IEnumerable<TSource>> Permutations<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            var list = source.ToList();

            if (list.Count > 1)
                return from s in list
                        from p in Permutations(list.Take(list.IndexOf(s)).Concat(list.Skip(list.IndexOf(s) + 1)))
                        select p.Prepend(s);

            return new[] { list };
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(XORDecryption());
            Console.ReadLine();
            return;
        }
        public static int XORDecryption()
        {
            StreamReader sr = new StreamReader("p059_cipher.txt");
            Dictionary<string, int> words = CommonWords();

            int[] cipher = sr.ReadToEnd().Split(',').Select(s => int.Parse(s)).ToArray();
            string key = "";

            foreach (var c in Key(cipher))
            {
                if (ValidKey(String.Concat(c), cipher))
                    key = String.Concat(c);
            }

            return ASCIISum("exp", cipher);
        }

        public static bool ValidKey(string key, int[] cipher)
        {
            Dictionary<string, int> words = CommonWords();

            string s = "";
            char c = ' ';

            for (int i = 0; i < cipher.Count(); i++)
            {
                c = (char)(cipher[i] ^ key[i % 3]);
                s += c;
            }

            int found = 0, unknown = 0;
            foreach (string str in s.Split(' '))
                if (words.ContainsKey(str))
                    found++;
                else
                    unknown++;

            if ((double)(found / unknown) > 1)
                return true;
            else
                return false;
        }

        public static int ASCIISum(string key, int[] cipher)
        {
            int sum = 0;
            for (int i = 0; i < cipher.Count(); i++)
                sum += (char) (key[i % 3] ^ cipher[i]);
            return sum;
        }

        public static List<IEnumerable<char>> Key(int[] cipher)
        {
            List<string> lst = new List<string> { "a", "b", "c" };
            List<char>   alpha = "abcdefghijklmnopqrstuvwxyz".ToList();
            List<char> common = " aeiouAEIOU.,[]()1234567890".ToList();

            Dictionary<string, int> words = CommonWords();

            for (int c = 0; c <= 2; c++)
                for (int i = 0, limit = alpha.Count(), temp = 0, largest = 0; i < limit; i++, temp = 0)
                {
                    string test = "";
                    for (int j = 0; j < cipher.Count(); j++, test = "")
                    {
                        char ch = (char)(cipher[j] ^ alpha[i]);
                        if (common.Contains(ch))
                            temp++;
                        test += ch;
                    }

                    foreach (string s in test.Split(' '))
                        if (words.ContainsKey(s))
                            temp++;

                    if (temp > largest)
                    {
                        largest = temp;
                        lst[c] = alpha[i].ToString();
                        alpha.Remove(alpha[i]);
                        limit--;
                    }
                }

            return (lst[0] + lst[1] + lst[2]).Permutations().ToList();
        }

        public static Dictionary<string, int> CommonWords()
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            StreamReader sr = new StreamReader("words.txt");

            for (string s = sr.ReadLine(); s != null; s = sr.ReadLine())
                d.Add(s, 0);
            return d;
        }
    }
}