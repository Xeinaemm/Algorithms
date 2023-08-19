using Algorithms.Structures;

namespace Algorithms.BinaryTrees;

public static class InvertBinaryTree
{
    // O(n) time | O(h) space
    public static void First(BinaryTree? tree)
    {
        if (tree == null)
            return;
        (tree.Left, tree.Right) = (tree.Right, tree.Left);
        First(tree.Left);
        First(tree.Right);
    }
}
