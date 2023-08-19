namespace Algorithms.DynamicProgramming;
public static class MaxSumIncreasingSubsequence
{
    // O(n^2) time | O(n) space
    public static List<List<int>> First(int[] array)
    {
        var sequences = new int[array.Length];
        Array.Fill(sequences, int.MinValue);
        var sums = (int[])array.Clone();
        var maxSumIdx = 0;
        for (var i = 0; i < array.Length; i++)
        {
            var currentNum = array[i];
            for (var j = 0; j < i; j++)
            {
                var otherNum = array[j];
                if (otherNum < currentNum && sums[j] + currentNum >= sums[i])
                {
                    sums[i] = sums[j] + currentNum;
                    sequences[i] = j;
                }
            }
            if (sums[i] >= sums[maxSumIdx])
                maxSumIdx = i;
        }
        return BuildSequence(array, sequences, maxSumIdx, sums[maxSumIdx]);
    }

    private static List<List<int>> BuildSequence(int[] array, int[] sequences, int currentIdx, int sums)
    {
        var sequence = new List<List<int>>
        {
            new List<int>() { sums },
            new List<int>()
        };
        while (currentIdx != int.MinValue)
        {
            sequence[1].Insert(0, array[currentIdx]);
            currentIdx = sequences[currentIdx];
        }

        return sequence;
    }
}
