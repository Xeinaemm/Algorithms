namespace Algorithms.Arrays;

public static class IsMonotonic
{
    // O(n) time | O(1) space
    public static bool First(int[] array)
    {
        var isNonDecreasing = true;
        var isNonIncreasing = true;
        for (var i = 0; i < array.Length - 1; i++)
        {
            if (array[i] > array[i + 1])
                isNonDecreasing = false;
            if (array[i] < array[i + 1])
                isNonIncreasing = false;
        }
        return isNonDecreasing || isNonIncreasing;
    }
}
