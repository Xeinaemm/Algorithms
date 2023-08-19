namespace Algorithms.Arrays;
public static class ZeroSumSubarray
{
    // O(n) time | O(n) space
    public static bool First(int[] nums)
    {
        var sums = new HashSet<int>();
        var sum = 0;
        _ = sums.Add(sum);
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (sums.Contains(sum))
                return true;
            else
                _ = sums.Add(sum);
        }
        return false;
    }
}
