using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class BstMinHeight
{
    // O(n) time | O(n) space
    public static BinarySeachTree? MinHeightBst(List<int> array) =>
        ContructMinHeightBst(array, 0, array.Count - 1);

    public static BinarySeachTree? ContructMinHeightBst(List<int> array, int startIdx, int endIdx)
    {
        if (endIdx < startIdx)
            return null;
        var midIdx = (startIdx + endIdx) / 2;
        var bst = new BinarySeachTree(array[midIdx])
        {
            Left = ContructMinHeightBst(array, startIdx, midIdx - 1),
            Right = ContructMinHeightBst(array, midIdx + 1, endIdx)
        };
        return bst;
    }
}
