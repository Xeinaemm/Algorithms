using Algorithms.Structures;

namespace Algorithms.BinaryTrees;

public static class SplitBinaryTree
{
    // O(n) time | O(h) space
    public static int First(BinaryTree tree)
    {
        var treeSum = SumTree(tree);
        if (treeSum % 2 != 0)
            return 0;
        var desiredSum = treeSum / 2;
        var treeInfo = EvaluateSplitBinaryTree(tree, desiredSum);
        return treeInfo.CanSplit ? desiredSum : 0;
    }

    public static TreeInfo EvaluateSplitBinaryTree(BinaryTree? tree, int desiredSum)
    {
        if (tree == null)
            return new TreeInfo(0, false);
        var leftTreeInfo = EvaluateSplitBinaryTree(tree.Left, desiredSum);
        var rightTreeInfo = EvaluateSplitBinaryTree(tree.Right, desiredSum);
        var currentSum = tree.Value + leftTreeInfo.CurrentSum + rightTreeInfo.CurrentSum;
        var canSplit = leftTreeInfo.CanSplit || rightTreeInfo.CanSplit || currentSum == desiredSum;
        return new TreeInfo(currentSum, canSplit);
    }

    public class TreeInfo
    {
        public int CurrentSum { get; set; }
        public bool CanSplit { get; set; }
        public TreeInfo(int currentSum, bool canSplit)
        {
            CurrentSum = currentSum;
            CanSplit = canSplit;
        }
    }

    public static int SumTree(BinaryTree? tree)
        => tree != null ? tree.Value + SumTree(tree.Left) + SumTree(tree.Right) : 0;
}
