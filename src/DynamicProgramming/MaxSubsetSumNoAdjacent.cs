namespace Algorithms.DynamicProgramming;
public static class MaxSubsetSumNoAdjacent
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        if (array.Length == 0)
            return 0;
        else if (array.Length == 1)
            return array[0];

        var first = array[0];
        var second = Math.Max(array[0], array[1]);
        for (var i = 2; i < array.Length; i++)
        {
            var current = Math.Max(second, first + array[i]);
            first = second;
            second = current;
        }
        return second;
    }
}
