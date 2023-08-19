namespace Algorithms.DynamicProgramming;
public static class LongestCommonSubsequence
{
    // O(nm) time | O(nm) space
    public static List<char> First(string str1, string str2)
    {
        var lengths = new int[str2.Length + 1, str1.Length + 1];
        for (var row = 1; row < str2.Length + 1; row++)
            for (var column = 1; column < str1.Length + 1; column++)
                lengths[row, column] = str2[row - 1] == str1[column - 1]
                    ? lengths[row - 1, column - 1] + 1
                    : Math.Max(lengths[row - 1, column], lengths[row, column - 1]);
        return BuildSequence(lengths, str1);
    }

    private static List<char> BuildSequence(int[,] lengths, string str)
    {
        var sequence = new List<char>();
        var row = lengths.GetLength(0) - 1;
        var column = lengths.GetLength(1) - 1;
        while (row != 0 && column != 0)
        {
            if (lengths[row, column] == lengths[row - 1, column])
                row--;
            else if (lengths[row, column] == lengths[row, column - 1])
                column--;
            else
            {
                sequence.Insert(0, str[column - 1]);
                row--;
                column--;
            }
        }
        return sequence;
    }
}
