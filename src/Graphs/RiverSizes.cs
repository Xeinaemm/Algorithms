namespace Algorithms.Graphs;
public static class RiverSizes
{
    // O(wh) time | O(wh) space
    public static List<int> First(int[,] matrix)
    {
        var result = new List<int>();
        for (var column = 0; column < matrix.GetLength(1); column++)
            for (var row = 0; row < matrix.GetLength(0); row++)
            {
                var riverSize = RiverSize(row, column, matrix);
                if (riverSize > 0)
                    result.Add(riverSize);
            }
        return result;
    }

    private static int RiverSize(int row, int column, int[,] matrix)
    {
        if (row >= 0 &&
            row < matrix.GetLength(0) &&
            column >= 0 &&
            column < matrix.GetLength(1) &&
            matrix[row, column] == 1)
        {
            matrix[row, column] = 0;
            return RiverSize(row + 1, column, matrix) +
                   RiverSize(row - 1, column, matrix) +
                   RiverSize(row, column + 1, matrix) +
                   RiverSize(row, column - 1, matrix) +
                   1;
        }
        return 0;
    }
}
