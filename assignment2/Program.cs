using CandyCrushLogic;

namespace assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("invalid number of arguments!");
                Console.WriteLine("usage: assignment [1-3] <nr of rows> <nr of columns>");
                return;
            }

            int numberOfRows = int.Parse(args[0]);
            int numberOfColumns = int.Parse(args[1]);

            Program myProgram = new Program();
            myProgram.Start(numberOfRows, numberOfColumns);
        }
        void Start(int numberOfRows, int numberOfColumns)
        {
            RegularCandies[,] playingField = new RegularCandies[numberOfRows, numberOfColumns];
            InitCandies(playingField);
            DisplayCandies(playingField);
            if (Class1.ScoreRowPresent(playingField))
            {
                Console.WriteLine("row score");
            }
            else
            {
                Console.WriteLine("no row score");
            }

            if (Class1.ScoreColumnPresent(playingField))
            {
                Console.WriteLine("column score");
            }
            else
            {
                Console.WriteLine("no column score");
            }
        }
        void InitCandies(RegularCandies[,] matrix)
        {
            Random random = new Random();
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = (RegularCandies)random.Next(0, 6);
                }
            }
        }
        void DisplayCandies(RegularCandies[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == RegularCandies.JellyBean)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (matrix[row, column] == RegularCandies.Lozenge)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else if (matrix[row, column] == RegularCandies.LemonDrop)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (matrix[row, column] == RegularCandies.GumSquare)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (matrix[row, column] == RegularCandies.LollipopHead)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (matrix[row, column] == RegularCandies.JujubeCluster)
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}