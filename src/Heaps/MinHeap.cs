namespace Algorithms.Heaps;
public class MinHeap(List<int> array)
{
    public List<int> Heap { get; } = BuildHeap(array);

    // O(n) time | O(1) space
    public static List<int> BuildHeap(List<int> array)
    {
        var firstParentIdx = (array.Count - 2) / 2;
        for (var i = firstParentIdx; i >= 0; i--)
            SiftDown(i, array.Count - 1, array);
        return array;
    }

    // O(log(n)) time | O(1) space
    public static void SiftDown(int currentIdx, int endIdx, List<int> heap)
    {
        var childOneIdx = (2 * currentIdx) + 1;
        while (childOneIdx <= endIdx)
        {
            var childTwoIdx = (2 * currentIdx) + 2 <= endIdx ? (currentIdx * 2) + 2 : -1;
            var idxToSwap = childTwoIdx != -1 && heap[childTwoIdx] < heap[childOneIdx] ? childTwoIdx : childOneIdx;
            if (heap[idxToSwap] < heap[currentIdx])
            {
                (heap[idxToSwap], heap[currentIdx]) = (heap[currentIdx], heap[idxToSwap]);
                currentIdx = idxToSwap;
                childOneIdx = (2 * currentIdx) + 1;
            }
            else
                return;
        }
    }

    // O(log(n)) time | O(1) space
    public static void SiftUp(int currentIdx, List<int> heap)
    {
        var parentNode = (currentIdx - 1) / 2;
        while (currentIdx > 0 && heap[currentIdx] < heap[parentNode])
        {
            (heap[parentNode], heap[currentIdx]) = (heap[currentIdx], heap[parentNode]);
            currentIdx = parentNode;
            parentNode = (currentIdx - 1) / 2;
        }
    }

    public int Peek() => Heap[0];

    public int Remove()
    {
        (Heap[^1], Heap[0]) = (Heap[0], Heap[^1]);
        var toRemove = Heap[^1];
        Heap.RemoveAt(Heap.Count - 1);
        SiftDown(0, Heap.Count - 1, Heap);
        return toRemove;
    }

    public void Insert(int value)
    {
        Heap.Add(value);
        SiftUp(Heap.Count - 1, Heap);
    }
}
