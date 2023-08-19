using Algorithms.Structures;

namespace Algorithms.BinaryTrees;

public static class HeightBalancedBinaryTree
{
    // O(n) time | O(h) space
    public static bool First(BinaryTree tree)
    {
        var treeInfo = EvaluateBinaryTree(tree);
        return treeInfo.IsBalanced;
    }

    public static TreeInfo EvaluateBinaryTree(BinaryTree? tree)
    {
        if (tree == null)
            return new TreeInfo(true, 0);
        var treeInfoLeft = EvaluateBinaryTree(tree.Left);
        var treeInfoRight = EvaluateBinaryTree(tree.Right);
        var isBalanced = treeInfoLeft.IsBalanced
            && treeInfoRight.IsBalanced
            && Math.Abs(treeInfoLeft.Height - treeInfoRight.Height) <= 1;
        var height = Math.Max(treeInfoLeft.Height, treeInfoRight.Height) + 1;
        return new TreeInfo(isBalanced, height);
    }

    public class TreeInfo
    {
        public bool IsBalanced { get; set; }
        public int Height { get; set; }
        public TreeInfo(bool isBalanced, int height)
        {
            IsBalanced = isBalanced;
            Height = height;
        }
    }
}
