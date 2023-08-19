using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class ValidateThreeNodes
{
    // O(d) time | O(1) space where d is depth of tree
    public static bool First(BinarySeachTree nodeOne, BinarySeachTree nodeTwo, BinarySeachTree nodeThree)
    {
        var searchOne = nodeOne;
        var searchTwo = nodeThree;
        while (true)
        {
            var foundThreeFromOne = searchOne == nodeThree;
            var foundOneFromThree = searchTwo == nodeOne;
            var foundNodeTwo = searchOne == nodeTwo || searchTwo == nodeTwo;
            var finishedSearching = searchOne == null && searchTwo == null;
            if (foundThreeFromOne || foundOneFromThree || foundNodeTwo || finishedSearching)
                break;
            if (searchOne != null)
                searchOne = searchOne.Value > nodeTwo.Value ? searchOne.Left : searchOne.Right;
            if (searchTwo != null)
                searchTwo = searchTwo.Value > nodeTwo.Value ? searchTwo.Left : searchTwo.Right;
        }
        var foundNodeFromOther = searchOne == nodeThree || searchTwo == nodeOne;
        var foundNodeTwoFinal = searchOne == nodeTwo || searchTwo == nodeTwo;
        return foundNodeTwoFinal && !foundNodeFromOther && SearchForTarget(nodeTwo, searchOne == nodeTwo ? nodeThree : nodeOne);
    }

    private static bool SearchForTarget(BinarySeachTree? node, BinarySeachTree? target)
    {
        while (node != null && node != target)
            node = target.Value < node.Value ? node.Left : node.Right;
        return node == target;
    }
}
