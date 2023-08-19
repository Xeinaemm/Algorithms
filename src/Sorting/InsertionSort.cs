namespace Algorithms.Sorting;

public static class InsertionSort
{
    // O(n^2) time | O(1) space
    public static int[] First(int[] array)
    {
        for (var i = 1; i < array.Length; i++)
        {
            var j = i;
            while (j > 0 && array[j] < array[j - 1])
            {
                (array[j - 1], array[j]) = (array[j], array[j - 1]);
                j -= 1;
            }
        }
        return array;
    }
}
