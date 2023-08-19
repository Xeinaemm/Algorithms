using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class BranchSums
{
    // O(n) time | O(log(n)) space
    public static List<int> First(BinaryTree root)
    {
        var sums = new List<int>();
        CalculateBranchSumsRecursion(root, 0, sums);
        return sums;
    }

    public static void CalculateBranchSumsRecursion(BinaryTree node, int sum, List<int> sums)
    {
        sum += node.Value;
        if (node.Left == null && node.Right == null)
            sums.Add(sum);
        if (node.Left != null)
            CalculateBranchSumsRecursion(node.Left, sum, sums);
        if (node.Right != null)
            CalculateBranchSumsRecursion(node.Right, sum, sums);
    }
}
