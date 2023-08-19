using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class MergeBinaryTrees
{
    // O(n) time | O(h) space
    public static BinaryTree? First(BinaryTree? tree1, BinaryTree? tree2)
    {
        if (tree1 == null)
            return tree2;
        if (tree2 == null)
            return tree1;
        tree1.Value += tree2.Value;
        tree1.Left = First(tree1.Left, tree2.Left);
        tree1.Right = First(tree1.Right, tree2.Right);
        return tree1;
    }
}
