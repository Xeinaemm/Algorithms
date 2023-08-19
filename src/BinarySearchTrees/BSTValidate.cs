using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class BstValidate
{
    // O(n) time | O(h) space
    public static bool ValidateBst(BinarySeachTree tree, int minValue = int.MinValue, int maxValue = int.MaxValue) =>
        tree.Value >= minValue && tree.Value < maxValue &&
               (tree.Left == null || ValidateBst(tree.Left, minValue, tree.Value)) &&
               (tree.Right == null || ValidateBst(tree.Right, tree.Value, maxValue));
}
