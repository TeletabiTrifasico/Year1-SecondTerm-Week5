namespace CandyCrushLogic
{
    public class Class1
    {
        public static bool ScoreRowPresent(RegularCandies[,] matrix)
        {
            int together = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 1; column < matrix.GetLength(1); column++)
                {
                    if (matrix[row, column] == matrix[row, column - 1])
                    {
                        together++;
                    }
                    else
                    {
                        together = 1;
                    }
                    if (together == 3)
                    {
                        return true;
                    }
                }
                together = 1;
            }
            return false;
        }
        public static bool ScoreColumnPresent(RegularCandies[,] matrix)
        {
            int together = 1;
            for (int column = 0; column < matrix.GetLength(1); column++)
            {
                for (int row = 1; row < matrix.GetLength(0); row++)
                {
                    if (matrix[row, column] == matrix[row - 1, column])
                    {
                        together++;
                    }
                    else
                    {
                        together = 1;
                    }
                    if (together == 3)
                    {
                        return true;
                    }
                }
                together = 1;
            }
            return false;
        }

    }
    public enum RegularCandies
    {
        JellyBean, 
        Lozenge, 
        LemonDrop, 
        GumSquare, 
        LollipopHead, 
        JujubeCluster
    }
}
