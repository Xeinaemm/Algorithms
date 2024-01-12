using Algorithms.Structures;

namespace Algorithms.BinaryTrees;

public class NodeDepths
{
    // O(n) time | O(h) space
    public static int First(BinaryTree root)
        => NodeDepthsRecursion(root, 0);

    // O(n) time | O(h) space
    public static int Second(BinaryTree root)
    {
        var stack = new Stack<Node>();
        var depthsSum = 0;
        stack.Push(new Node(root, 0));

        while (stack.Count != 0)
        {
            var node = stack.Pop();
            if (node == null)
                continue;
            depthsSum += node.Depth;
            if (node.InnerNode.Right != null)
                stack.Push(new Node(node.InnerNode.Right, node.Depth + 1));
            if (node.InnerNode.Left != null)
                stack.Push(new Node(node.InnerNode.Left, node.Depth + 1));
        }
        return depthsSum;
    }

    public static int NodeDepthsRecursion(BinaryTree node, int depth)
    {
        var leftNode = 0;
        var rightNode = 0;
        if (node.Left != null)
            leftNode = NodeDepthsRecursion(node.Left, depth + 1);
        if (node.Right != null)
            rightNode = NodeDepthsRecursion(node.Right, depth + 1);
        return depth + leftNode + rightNode;
    }

    public class Node(BinaryTree node, int depth)
    {
        public int Depth { get; set; } = depth;
        public BinaryTree InnerNode { get; set; } = node;
    }
}
