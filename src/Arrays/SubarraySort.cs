namespace Algorithms.Arrays;
public static class SubarraySort
{
    // O(n) time | O(1) space
    public static int[] First(int[] array)
    {
        var smallestUnsorted = int.MaxValue;
        var highestUnsorted = int.MinValue;
        for (var i = 0; i < array.Length; i++)
        {
            if (IsOutOfOrder(i, array))
            {
                smallestUnsorted = Math.Min(smallestUnsorted, array[i]);
                highestUnsorted = Math.Max(highestUnsorted, array[i]);
            }
        }
        if (smallestUnsorted == int.MaxValue)
            return new int[] { -1, -1 };
        var leftPtr = 0;
        var rightPtr = array.Length - 1;
        while (smallestUnsorted >= array[leftPtr])
            leftPtr++;
        while (highestUnsorted <= array[rightPtr])
            rightPtr--;
        return new int[] { leftPtr, rightPtr };
    }

    public static bool IsOutOfOrder(int i, int[] array)
    {
        if (i == 0)
            return array[i] > array[i + 1];
        else if (i == array.Length - 1)
            return array[i] < array[i - 1];
        return array[i - 1] > array[i] || array[i] > array[i + 1];
    }
}
