namespace Algorithms.Arrays;

public static class MissingNumbers
{
    // O(n) time | O(n) space
    public static int[] First(int[] nums)
    {
        var numbers = new HashSet<int>(nums);
        var result = new List<int>();
        for (var i = 1; i <= nums.Length + 2; i++)
        {
            if (!numbers.Contains(i))
                result.Add(i);
        }
        return result.ToArray();
    }
}
