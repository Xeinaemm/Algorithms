using Algorithms.Structures;

namespace Algorithms.BinaryTrees;

public class EvaluateExpressionTree
{
    // O(n) time | O(h) space
    public int First(BinaryTree? tree) => tree?.Value switch
    {
        -1 => First(tree.Left) + First(tree.Right),
        -2 => First(tree.Left) - First(tree.Right),
        -3 => First(tree.Left) / First(tree.Right),
        -4 => First(tree.Left) * First(tree.Right),
        _ => tree?.Value ?? 0,
    };
}
