using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;

public static class BstKthLargestValue
{
    public class TreeInfo
    {
        public int Visited { get; set; }
        public int LatestValue { get; set; }
        public TreeInfo(int visited, int latestValue)
        {
            Visited = visited;
            LatestValue = latestValue;
        }
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
