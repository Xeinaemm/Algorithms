namespace Algorithms.Arrays;
public static class LongestPeak
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        var longestPeak = 0;
        for (var i = 1; i < array.Length - 1; i++)
        {
            var newLongestPeak = 0;
            if (array[i - 1] < array[i] && array[i] > array[i + 1])
            {
                newLongestPeak++;
                var idx = i;
                while (idx > 0 && array[idx - 1] < array[idx])
                {
                    newLongestPeak++;
                    idx--;
                }
                idx = i;
                while (idx < array.Length - 1 && array[idx] > array[idx + 1])
                {
                    newLongestPeak++;
                    idx++;
                }
                i = idx;
            }
            if (newLongestPeak > longestPeak)
                longestPeak = newLongestPeak;
        }
        return longestPeak;
    }
}
