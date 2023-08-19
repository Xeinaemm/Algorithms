using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class RepairBst
{
    // O(n) time | O(h) space where h is height of tree
    public static BinarySeachTree First(BinarySeachTree tree)
    {
        BinarySeachTree? nodeOne = null, nodeTwo = null, previousNode = null;
        var stack = new Stack<BinarySeachTree>();
        var currentNode = tree;
        while (currentNode != null || stack.Count > 0)
        {
            while (currentNode != null)
            {
                stack.Push(currentNode);
                currentNode = currentNode.Left;
            }
            currentNode = stack.Pop();
            if (previousNode != null && previousNode.Value > currentNode.Value)
            {
                nodeOne ??= previousNode;
                nodeTwo = currentNode;
            }
            previousNode = currentNode;
            currentNode = currentNode.Right;
        }
        (nodeOne.Value, nodeTwo.Value) = (nodeTwo.Value, nodeOne.Value);
        return tree;
    }
}
