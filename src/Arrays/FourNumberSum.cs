namespace Algorithms.Arrays;
public static class FourNumberSum
{
    // Average: O(n^2) time | O(n^2) space
    // Worst: O(n^3) time | O(n^2) space
    public static List<int[]> First(int[] array, int targetSum)
    {
        var pairSums = new Dictionary<int, List<int[]>>();
        var result = new List<int[]>();
        for (var i = 1; i < array.Length - 1; i++)
        {
            for (var j = i + 1; j < array.Length; j++)
            {
                var currentSum = array[i] + array[j];
                var diff = targetSum - currentSum;
                if (pairSums.ContainsKey(diff))
                    foreach (var pair in pairSums[diff])
                        result.Add(new int[] { pair[0], pair[1], array[i], array[j] });
            }
            for (var k = 0; k < i; k++)
            {
                var currentSum = array[i] + array[k];
                var pair = new int[] { array[k], array[i] };
                if (!pairSums.ContainsKey(currentSum))
                    pairSums.Add(currentSum, new List<int[]> { pair });
                else
                    pairSums[currentSum].Add(pair);
            }
        }
        return result;
    }
}
