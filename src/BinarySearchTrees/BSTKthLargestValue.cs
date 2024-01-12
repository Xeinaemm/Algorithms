using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;

public static class BstKthLargestValue
{
    public class TreeInfo(int visited, int latestValue)
    {
        public int Visited { get; set; } = visited;
        public int LatestValue { get; set; } = latestValue;
    }

    // O(h + k) time | O(h) space
    public static int FindKthLargestValueInBst(BinarySeachTree tree, int k)
    {
        var treeInfo = new TreeInfo(0, -1);
        ReverseInOrderTraverse(tree, k, treeInfo);
        return treeInfo.LatestValue;
    }

    public static void ReverseInOrderTraverse(BinarySeachTree? node, int k, TreeInfo treeInfo)
    {
        if (node == null || treeInfo.Visited >= k)
            return;
        ReverseInOrderTraverse(node.Right, k, treeInfo);
        if (treeInfo.Visited < k)
        {
            treeInfo.Visited += 1;
            treeInfo.LatestValue = node.Value;
            ReverseInOrderTraverse(node.Left, k, treeInfo);
        }
    }
}
