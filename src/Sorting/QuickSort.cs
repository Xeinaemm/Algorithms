namespace Algorithms.Sorting;
internal class QuickSort
{
    // Best: O(nlog(n)) time | O(log(n)) space
    // Avg: O(nlog(n)) time | O(log(n)) space
    // Worst: O(n^2) time | O(log(n)) space
    public static int[] Sort(int[] array)
    {
        Sort(array, 0, array.Length - 1);
        return array;
    }

    public static void Sort(int[] array, int startIdx, int endIdx)
    {
        if (startIdx >= endIdx)
            return;
        var pivotIdx = startIdx;
        var leftIdx = startIdx + 1;
        var rightIdx = endIdx;

        while (rightIdx >= leftIdx)
        {
            if (array[leftIdx] > array[pivotIdx] && array[rightIdx] < array[pivotIdx])
                (array[leftIdx], array[rightIdx]) = (array[rightIdx], array[leftIdx]);
            if (array[leftIdx] <= array[pivotIdx])
                leftIdx++;
            if (array[rightIdx] >= array[pivotIdx])
                rightIdx--;
        }
        (array[pivotIdx], array[rightIdx]) = (array[rightIdx], array[pivotIdx]);

        var leftSubarrayIsSmaller = rightIdx - 1 - startIdx < endIdx - (rightIdx + 1);
        if (leftSubarrayIsSmaller)
        {
            Sort(array, startIdx, rightIdx - 1);
            Sort(array, rightIdx + 1, endIdx);
        }
        else
        {
            Sort(array, rightIdx + 1, endIdx);
            Sort(array, startIdx, rightIdx - 1);
        }
    }
}
