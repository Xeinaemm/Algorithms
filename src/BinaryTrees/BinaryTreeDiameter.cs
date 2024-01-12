using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class BinaryTreeDiameter
{
    // Average case: O(n) time | O(h) space
    // Worst case: O(n) time | O(n) space
    // Diameter its longest path in tree. Start from the left most and right most place and sum max height and diameter.
    public static int First(BinaryTree? tree)
        => GetTreeInfo(tree).Diameter;

    public static TreeInfo GetTreeInfo(BinaryTree? tree)
    {
        if (tree == null)
            return new TreeInfo(0, 0);
        var leftTreeInfo = GetTreeInfo(tree.Left);
        var rightTreeInfo = GetTreeInfo(tree.Right);

        var longestPath = leftTreeInfo.Height + rightTreeInfo.Height;
        var maxDiameter = Math.Max(leftTreeInfo.Diameter, rightTreeInfo.Diameter);
        var currentDiameter = Math.Max(longestPath, maxDiameter);
        var currentHeight = Math.Max(leftTreeInfo.Height, rightTreeInfo.Height) + 1;
        return new TreeInfo(currentDiameter, currentHeight);
    }

    public record TreeInfo(int Diameter, int Height);
}
