using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class SymmetricalTree
{
    // O(n) time | O(h) space
    public static bool First(BinaryTree? tree)
        => EvaluateSymmetric(tree?.Left, tree?.Right);

    public static bool EvaluateSymmetric(BinaryTree? left, BinaryTree? right)
        => left != null && right != null && left.Value == right.Value ?
            EvaluateSymmetric(left.Left, right.Right) &&
                EvaluateSymmetric(left.Right, right.Left) :
            left == right;
}
