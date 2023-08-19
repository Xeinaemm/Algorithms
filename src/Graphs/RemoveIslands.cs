namespace Algorithms.Graphs;
public class RemoveIslands
{
    // O(wh) time | O(wh) space
    public int[][] First(int[][] matrix)
    {
        var rowLength = matrix.Length;
        var columnLength = matrix[0].Length;

        for (var row = 0; row < rowLength; row++)
        {
            MarkBorder(ref matrix, row, 0);
            MarkBorder(ref matrix, row, columnLength - 1);
        }

        for (var column = 0; column < columnLength; column++)
        {
            MarkBorder(ref matrix, 0, column);
            MarkBorder(ref matrix, rowLength - 1, column);
        }

        for (var column = 0; column < columnLength; column++)
            for (var row = 0; row < rowLength; row++)
                if (matrix[row][column] == 1)
                    matrix[row][column] = 0;
                else if (matrix[row][column] == 2)
                    matrix[row][column] = 1;
        return matrix;
    }

    private static void MarkBorder(ref int[][] matrix, int row, int column)
    {
        if (row >= 0 &&
            row < matrix.Length &&
            column >= 0 &&
            column < matrix[0].Length &&
            matrix[row][column] == 1)
        {
            matrix[row][column] = 2;
            MarkBorder(ref matrix, row + 1, column);
            MarkBorder(ref matrix, row - 1, column);
            MarkBorder(ref matrix, row, column + 1);
            MarkBorder(ref matrix, row, column - 1);
        }
    }
}
