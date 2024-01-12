using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class MaxPathSum
{
    // O(n) time | O(log(n)) space
    public static int First(BinaryTree tree) =>
        FindMaxSum(tree).MaxPathSum;

    private static TreeInfo FindMaxSum(BinaryTree? tree)
    {
        if (tree == null)
            return new TreeInfo();
        var left = FindMaxSum(tree.Left);
        var right = FindMaxSum(tree.Right);
        var maxChildSum = Math.Max(left.MaxBranchSum, right.MaxBranchSum);
        var maxBranchSum = Math.Max(maxChildSum + tree.Value, tree.Value);
        var maxRootSum = Math.Max(left.MaxBranchSum + right.MaxBranchSum + tree.Value, maxBranchSum);
        var maxPathSum = Math.Max(left.MaxPathSum, Math.Max(right.MaxPathSum, maxRootSum));
        return new TreeInfo(maxBranchSum, maxPathSum);
    }

    public class TreeInfo(int maxBranchSum = 0, int maxPathSum = int.MinValue)
    {
        public int MaxBranchSum { get; private set; } = maxBranchSum;
        public int MaxPathSum { get; private set; } = maxPathSum;
    }
}
