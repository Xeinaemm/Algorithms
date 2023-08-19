using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class BstReconstruction
{
    public class TreeInfo
    {
        public int RootIdx { get; set; }
        public TreeInfo(int rootIdx) => RootIdx = rootIdx;
    }

    // O(n) time | O(n) space
    public static BinarySeachTree? ReconstructBst(List<int> preOrderTraversalValues)
    {
        var treeInfo = new TreeInfo(0);
        return ReconstructBstFromRange(int.MinValue, int.MaxValue, preOrderTraversalValues, treeInfo);
    }
    public static BinarySeachTree? ReconstructBstFromRange(int lowerBound, int upperBound, List<int> preOrderTraversalValues, TreeInfo treeInfo)
    {
        if (treeInfo.RootIdx == preOrderTraversalValues.Count)
            return null;
        var rootValue = preOrderTraversalValues[treeInfo.RootIdx];
        if (rootValue < lowerBound || rootValue >= upperBound)
            return null;
        treeInfo.RootIdx += 1;

        var bst = new BinarySeachTree(rootValue)
        {
            Left = ReconstructBstFromRange(lowerBound, rootValue, preOrderTraversalValues, treeInfo),
            Right = ReconstructBstFromRange(rootValue, upperBound, preOrderTraversalValues, treeInfo)
        };
        return bst;
    }
}
