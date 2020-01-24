//The Problem can be found here: https://projecteuler.net/problem=67
using System;
using System.IO;

namespace PE067
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(MaximumSumPathII());
            Console.ReadLine();
            return;
        }

        public static int[][] LoadTriangle()
        {
            string[] lines = File.ReadAllText("triangle.txt").Split('\n');
            return lines.Select(l => l.Split().Select(n => int.Parse(n)).ToArray()).ToArray();
        }

        public static int[] CombineRow(int[][] triangle, int i)
        {
            int[] arr = new int[triangle[i].Length];
            for (int j = 0; j < triangle[i].Length; j++)
            {
                if (triangle[i + 1][j] > triangle[i + 1][j + 1])
                    arr[j] = triangle[i][j] + triangle[i + 1][j];
                else
                    arr[j] = triangle[i][j] + triangle[i + 1][j + 1];
            }
            return arr;
        }

        public static int MaximumSumPathII()
        {
            int[][] triangle = LoadTriangle();
            for (int i = triangle.Length - 2; i >= 0; i--)
                triangle[i] = CombineRow(triangle, i);

            return triangle[0][0];
        }
    }
}