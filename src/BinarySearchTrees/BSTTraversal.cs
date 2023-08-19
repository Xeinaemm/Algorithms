using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class BstTraversal
{
    // O(n) time | O(n) space
    public static List<int> InOrderTraverse(BinarySeachTree tree, List<int> array)
    {
        if (tree.Left != null)
            _ = InOrderTraverse(tree.Left, array);
        array.Add(tree.Value);
        if (tree.Right != null)
            _ = InOrderTraverse(tree.Right, array);
        return array;
    }

    // O(n) time | O(n) space
    public static List<int> PreOrderTraverse(BinarySeachTree tree, List<int> array)
    {
        array.Add(tree.Value);
        if (tree.Left != null)
            _ = PreOrderTraverse(tree.Left, array);
        if (tree.Right != null)
            _ = PreOrderTraverse(tree.Right, array);
        return array;
    }

    // O(n) time | O(n) space
    public static List<int> PostOrderTraverse(BinarySeachTree tree, List<int> array)
    {
        if (tree.Left != null)
            _ = PostOrderTraverse(tree.Left, array);
        if (tree.Right != null)
            _ = PostOrderTraverse(tree.Right, array);
        array.Add(tree.Value);
        return array;
    }
}
