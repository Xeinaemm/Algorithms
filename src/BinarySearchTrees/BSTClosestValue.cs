using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;

public static class BstClosestValue
{
    // Average: O(log(n)) time | O(1) space
    // Worst: O(n) time | O(1) space
    public static int First(BinarySeachTree tree, int target)
        => FindClosestValueInBstIteration(tree, target, tree.Value);

    private static int FindClosestValueInBstIteration(BinarySeachTree? tree, int target, int closest)
    {
        var currentNode = tree;
        while (currentNode != null)
        {
            if (Math.Abs(target - closest) > Math.Abs(target - currentNode.Value))
                closest = currentNode.Value;
            if (target < currentNode.Value)
                currentNode = currentNode.Left;
            else if (target > currentNode.Value)
                currentNode = currentNode.Right;
            else
                break;
        }
        return closest;
    }
}
