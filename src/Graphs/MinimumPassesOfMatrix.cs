namespace Algorithms.Graphs;

public class MinimumPassesOfMatrix
{
    // O(wh) time | O(wh) space
    public int First(int[][] matrix)
    {
        var queue = GetPositivePositions(ref matrix);

        var result = 0;
        while (queue.Count > 0)
        {
            var queueSize = queue.Count;
            while (queueSize > 0)
            {
                var coords = queue.Dequeue();
                var row = coords[0];
                var column = coords[1];
                TryNegateNumber(ref queue, ref matrix, row - 1, column);
                TryNegateNumber(ref queue, ref matrix, row + 1, column);
                TryNegateNumber(ref queue, ref matrix, row, column - 1);
                TryNegateNumber(ref queue, ref matrix, row, column + 1);
                queueSize--;
            }
            result++;
        }
        return ContainsNegatives(ref matrix) ? -1 : result - 1;
    }

    private static void TryNegateNumber(ref Queue<int[]> queue, ref int[][] matrix, int row, int column)
    {
        if (row >= 0 && column >= 0 &&
            row < matrix.Length && column < matrix[row].Length &&
            matrix[row][column] < 0)
        {
            matrix[row][column] *= -1;
            queue.Enqueue(new int[] { row, column });
        }
    }

    private static bool ContainsNegatives(ref int[][] matrix)
    {
        for (var row = 0; row < matrix.Length; row++)
            for (var column = 0; column < matrix[row].Length; column++)
                if (matrix[row][column] < 0)
                    return true;
        return false;
    }

    private static Queue<int[]> GetPositivePositions(ref int[][] matrix)
    {
        var queue = new Queue<int[]>();
        for (var row = 0; row < matrix.Length; row++)
            for (var column = 0; column < matrix[row].Length; column++)
                if (matrix[row][column] > 0)
                    queue.Enqueue(new int[] { row, column });
        return queue;
    }
}

