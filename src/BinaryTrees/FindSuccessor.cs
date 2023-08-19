using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class FindSuccessor
{
    // O(h) time | O(1) space
    public static BinaryTree? First(BinaryTree tree, BinaryTree node)
        => node.Right != null ? GetLeftmostChild(node.Right) : GetRightmostParent(node);

    // O(h) time | O(n) space
    public static BinaryTree? Second(BinaryTree tree, BinaryTree node)
    {
        var inOrderTraversalOrder = new List<BinaryTree>();
        GetInOrderTraversalOrder(tree, inOrderTraversalOrder);

        for (var i = 0; i < inOrderTraversalOrder.Count; i++)
        {
            var currentNode = inOrderTraversalOrder[i];

            if (currentNode != node)
                continue;

            if (i == inOrderTraversalOrder.Count - 1)
                return null;

            return inOrderTraversalOrder[i + 1];
        }
        return null;
    }

    private static BinaryTree? GetLeftmostChild(BinaryTree node)
    {
        var currentNode = node;
        while (currentNode.Left != null)
            currentNode = currentNode.Left;
        return currentNode;
    }

    private static BinaryTree? GetRightmostParent(BinaryTree node)
    {
        var currentNode = node;
        if (currentNode.Parent != null && currentNode.Parent.Right == currentNode)
            currentNode = currentNode.Parent;
        return currentNode.Parent;
    }

    private static void GetInOrderTraversalOrder(BinaryTree? node, List<BinaryTree> order)
    {
        if (order == null)
            return;
        GetInOrderTraversalOrder(node?.Left, order);
        order.Add(node);
        GetInOrderTraversalOrder(node?.Right, order);
    }
}
