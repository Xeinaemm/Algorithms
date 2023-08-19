namespace Algorithms.Searching;

public static class ThreeLargestNumbers
{
    // O(nm) time | O(m) space, in this case m is constant
    public static int[] First(int[] array, int m = 3)
    {
        var result = Enumerable.Range(int.MinValue, m).ToArray();
        foreach (var number in array)
            for (var j = result.Length - 1; j >= 0; j--)
                if (number > result[j])
                {
                    for (var k = 0; k <= j; k++)
                        result[k] = k == j ? number : result[k + 1];
                    break;
                }

        return result;
    }
}
