namespace Algorithms.Sorting;

public static class SelectionSort
{
    // O(n^2) time | O(1) space

    public static int[] First(int[] array)
    {
        for (var i = 0; i < array.Length; i++)
        {
            var smallestNumberIndex = i;
            for (var j = i + 1; j < array.Length; j++)
                if (array[smallestNumberIndex] > array[j])
                    smallestNumberIndex = j;
            (array[i], array[smallestNumberIndex]) = (array[smallestNumberIndex], array[i]);
        }
        return array;
    }
}
