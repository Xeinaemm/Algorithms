namespace Algorithms.Arrays;
public static class FirstDuplicateValue
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            var value = Math.Abs(array[i]);
            var indexToCheck = value - 1;
            if (array[indexToCheck] < 0)
                return value;
            array[indexToCheck] *= -1;
        }
        return -1;
    }
}
