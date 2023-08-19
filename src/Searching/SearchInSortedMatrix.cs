namespace Algorithms.Searching;
public static class SearchInSortedMatrix
{
    // O(w + h) time | O(1) space
    public static int[] First(int[,] matrix, int target)
    {
        var startRow = 0;
        var startColumn = matrix.GetLength(1) - 1;
        while (startRow < matrix.GetLength(0) && startColumn >= 0)
            if (matrix[startRow, startColumn] > target)
                startColumn--;
            else if (matrix[startRow, startColumn] < target)
                startRow++;
            else
                return new int[] { startRow, startColumn };
        return new int[] { -1, -1 };
    }
}
