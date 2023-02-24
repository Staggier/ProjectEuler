// The Problem can be found here: https://projecteuler.net/problem=96

namespace PE096
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sudoku());
            Console.ReadLine();
            return;
        }

        public static int Sudoku()
        {
            List<int[,]> game = SudokuGames();
            int sum = 0;

            for (int i = 0; i < 50; i++)
                SolveGame(game[i], ref sum);

            return sum;
        }
        
        // Checks if the passed digit is valid within its row and column.
        public static bool RowColCheck(int[,] game, int x, int y, int digit)
        {
            for (int i = 0; i <= 8; i++)
                if (game[y, i] == digit)
                    return true;

            for (int i = 0; i <= 8; i++)
                if (game[i, x] == digit)
                    return true;

            return false;
        }

        // Checks if the passed digit is valid within its quadrant.
        public static bool QuadCheck(int[,] game, int x, int y, int digit)
        {
            int xMin = (x >= 0 && x <= 2) ? 0 : (x >= 3 && x <= 5) ? 3 : (x >= 6 && x <= 8) ? 6 : -1, xMax = xMin + 2,
                yMin = (y >= 0 && y <= 2) ? 0 : (y >= 3 && y <= 5) ? 3 : (y >= 6 && y <= 8) ? 6 : -1, yMax = yMin + 2;

            for (int i = yMin; i <= yMax; i++)
                for (int j = xMin; j <= xMax; j++)
                    if (game[i, j] == digit)
                        return true;

            return false;
        }

        // Combines the two previous checks for a passed digit.
        public static bool ValidDigit(int[,] game, int x, int y, int digit)
        {
            if (RowColCheck(game, x, y, digit) || QuadCheck(game, x, y, digit))
                return false;
            else
                return true;
        }

        // Checks for an empty cell, if there aren't any then the puzzle is complete.
        public static bool Solved(int[,] game, ref int x, ref int y)
        {
            for (int i = 0; i <= 8; i++)
                for (int j = 0; j <= 8; j++)
                    if (game[(y = i), (x = j)] == 0)
                        return false;
            return true;
        }

        // SolveGame uses a backtracking algorithm to solve each sudoku puzzle. It simply places
        // valid digits until none are available and if the puzzle isn't completed it will reset
        // the cell to its default and then return back to its last call and places the next digit
        // until the puzzle is finally complete.
        public static void SolveGame(int[,] game, ref int sum)
        {
            int x = 0, y = 0;
            if (Solved(game, ref x, ref y))
            {               
                sum += (game[0, 0] * 100) + (game[0, 1] * 10) + game[0, 2];
                return;
            }

            for (int d = 1; d <= 9; d++)
            {
                if (ValidDigit(game, x, y, d))
                {
                    game[y, x] = d;
                    SolveGame(game, ref sum);
                }
            }

            game[y, x] = 0;
        }

        public static List<int[,]> SudokuGames()
        {
            StreamReader sr = new StreamReader("p096_sudoku.txt");
            List<int[,]> games = new List<int[,]>();

            string[] lines = sr.ReadToEnd().Split('\n');
            for (int i = 0, j = 0, k = 0, l = -1; k <= 499; j = 0, k++)
            {
                if (!int.TryParse(lines[k], out int n))
                {
                    games.Add(new int[9, 9]);
                    l++;
                    i = 0;

                    continue;
                }

                // Subtracting a character by '0' will convert it into an integer.
                foreach (char c in lines[k])
                    if (j <= 8)
                        games[l][i, j++] = c - '0';
                i++;
            }
            return games;
        }
    }
}