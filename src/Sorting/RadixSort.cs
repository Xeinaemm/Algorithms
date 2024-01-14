namespace Algorithms.Sorting;
public static class RadixSort
{
    public static List<int> Sort(List<int> array)
    {
        if (array.Count == 0)
            return array;
        var maxNumber = array.Max();
        var digit = 0;
        while ((maxNumber / Math.Pow(10, digit)) > 0)
        {
            CountingSort(array, digit);
            digit += 1;
        }
        return array;
    }

    private static void CountingSort(List<int> array, int digit)
    {
        var sortedArray = new int[array.Count];
        var countArray = new int[10];
        var digitColumn = (int)Math.Pow(10, digit);
        foreach (var num in array)
        {
            var countIndex = num / digitColumn % 10;
            countArray[countIndex] += 1;
        }

        for (var i = 1; i < 10; i++)
            countArray[i] += countArray[i - 1];

        for (var i = array.Count - 1; i > -1; i--)
        {
            var countIndex = array[i] / digitColumn % 10;
            countArray[countIndex] -= 1;
            var sortedIndex = countArray[countIndex];
            sortedArray[sortedIndex] = array[i];
        }

        for (var i = 0; i < array.Count; i++)
            array[i] = sortedArray[i];
    }
}
