namespace Algorithms.Arrays;
public static class TransposeMatrix
{
    // O(r + c) time | O(r + c) space
    public static int[,] First(int[,] matrix)
    {
        var rows = matrix.GetLength(0);
        var columns = matrix.GetLength(1);
        var transposedMatrix = new int[columns, rows];
        for (var col = 0; col < columns; col++)
            for (var row = 0; row < rows; row++)
                transposedMatrix[col, row] = matrix[row, col];
        return transposedMatrix;
    }
}
