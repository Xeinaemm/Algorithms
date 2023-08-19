namespace Algorithms.Arrays;

public static class MergeOverlappingIntervals
{
    // O(nlog(n)) time | O(n) space
    public static int[][] First(int[][] intervals)
    {
        Array.Sort(intervals, (x, y) => x[0].CompareTo(y[0]));
        var result = new List<int[]>();
        var currentInterval = intervals[0];
        result.Add(currentInterval);
        foreach (var interval in intervals)
            if (currentInterval[1] >= interval[0])
                currentInterval[1] = Math.Max(currentInterval[1], interval[1]);
            else
            {
                currentInterval = interval;
                result.Add(currentInterval);
            }
        return result.ToArray();
    }
}
