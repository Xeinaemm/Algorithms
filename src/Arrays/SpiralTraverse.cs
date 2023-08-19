namespace Algorithms.Arrays;
public static class SpiralTraverse
{
    // O(n) time | O(n) space
    public static List<int> First(int[,] array)
    {
        var startRow = 0;
        var startColumn = 0;
        var endRow = array.GetLength(0) - 1;
        var endColumn = array.GetLength(1) - 1;
        var result = new List<int>();
        while (startColumn <= endColumn && startRow <= endRow)
        {
            for (var col = startColumn; col <= endColumn; col++)
                result.Add(array[startRow, col]);
            for (var row = startRow + 1; row <= endRow; row++)
                result.Add(array[row, endColumn]);
            for (var col = endColumn - 1; col >= startColumn; col--)
            {
                if (startRow == endRow)
                    break;
                result.Add(array[endRow, col]);
            }
            for (var row = endRow - 1; row > startRow; row--)
            {
                if (startColumn == endColumn)
                    break;
                result.Add(array[row, startColumn]);
            }
            startRow++;
            startColumn++;
            endRow--;
            endColumn--;
        }
        return result;
    }
}
