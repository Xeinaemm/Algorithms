namespace Algorithms.Sorting;

public static class BubbleSort
{
    // O(n^2) time | O(1) space
    public static int[] First(int[] array)
    {
        var sorted = false;
        var counter = 0;
        while (!sorted)
        {
            sorted = true;
            for (var i = 0; i < array.Length - 1 - counter; i++)
                if (array[i] > array[i + 1])
                {
                    (array[i], array[i + 1]) = (array[i + 1], array[i]);
                    sorted = false;
                }
            counter++;
        }

        return array;
    }
}
