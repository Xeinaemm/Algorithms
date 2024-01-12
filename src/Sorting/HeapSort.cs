namespace Algorithms.Sorting;
internal class HeapSort
{
    // Best: O(nlog(n)) time | O(1) space
    // Avg: O(nlog(n)) time | O(1) space
    // Worst: O(nlog(n)) time | O(1) space
    public static int[] Sort(int[] array)
    {
        BuildMaxHeap(array);
        for (var endIdx = array.Length - 1; endIdx > 0; endIdx--)
        {
            (array[endIdx], array[0]) = (array[0], array[endIdx]);
            SiftDown(0, endIdx - 1, array);
        }
        return array;
    }

    public static void BuildMaxHeap(int[] array)
    {
        var firstParentIdx = (array.Length - 2) / 2;
        for (var currentIdx = firstParentIdx; currentIdx >= 0; currentIdx--)
            SiftDown(currentIdx, array.Length - 1, array);
    }

    public static void SiftDown(int currentIdx, int endIdx, int[] heap)
    {
        var childOneIdx = (currentIdx * 2) + 1;
        while (childOneIdx <= endIdx)
        {
            var childTwoIdx = (currentIdx * 2) + 2 <= endIdx ? (currentIdx * 2) + 2 : -1;
            var idxToSwap = childTwoIdx != -1 && heap[childTwoIdx] > heap[childOneIdx] ?
                childTwoIdx :
                childOneIdx;
            if (heap[idxToSwap] > heap[currentIdx])
            {
                (heap[idxToSwap], heap[currentIdx]) = (heap[currentIdx], heap[idxToSwap]);
                currentIdx = idxToSwap;
                childOneIdx = (currentIdx * 2) + 1;
            }
            else
                return;
        }
    }
}