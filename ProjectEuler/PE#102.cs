using System;
using System.IO;
using System.Linq;

namespace PE102
{
    class Program
    {
        static Main(string[] args)
        {
            Console.WriteLine(PE102());
            Console.ReadLine();
        }
        public struct Point { public double x, y; };
        public struct Triangle { public Point a, b, c; };

        public static double TriAreaPoints(Point A, Point B, Point C)
        {
            return 0.5 * Math.Abs(((A.x - C.x) * (B.y - A.y)) - ((A.x - B.x) * (C.y - A.y)));
        }

        public static bool TContainsP(Triangle T, Point P)
        {
            if (TriAreaPoints(T.a, T.b, T.c) == TriAreaPoints(T.a, T.b, P) + TriAreaPoints(T.a, P, T.c) + TriAreaPoints(P, T.b, T.c))
                return true;
            else
                return false;
        }

        public static int PE102()
        {
            int counter = 0;
            StreamReader sr = new StreamReader("p102_triangles.txt");
            List<Triangle> triangles = new List<Triangle>();

            string line = "", temp = "";
            while ((line = sr.ReadLine()) != null)
            {
                List<double> lst = new List<double>();
                List<Point> plst = new List<Point>();

                foreach (char c in line)
                {
                    if (c == ',' || c == '\n' || c == ' ')
                    {
                        lst.Add(Convert.ToDouble(temp));
                        temp = "";
                    }
                    else
                        temp += c;
                }
                lst.Add(Convert.ToDouble(temp));
                temp = "";

                for (int i = 0; i <= 5; i += 2)
                    plst.Add(new Point { x = lst[i], y = lst[i + 1] });

                triangles.Add(new Triangle { a = plst[0], b = plst[1], c = plst[2] });
            }

            foreach (Triangle t in triangles)
                if (TContainsP(t, new Point { x = 0, y = 0 }))
                    counter++;

            return counter;
        }
    }
}