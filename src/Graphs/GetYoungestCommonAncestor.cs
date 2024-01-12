namespace Algorithms.Graphs;
public static class GetYoungestCommonAncestor
{
    // O(d) time | O(1) space where d is depth of the ancestral
    public static AncestralTree? First(
        AncestralTree topAncestor,
        AncestralTree descendantOne,
        AncestralTree descendantTwo)
    {
        var depthOne = GetDepth(descendantOne, topAncestor);
        var depthTwo = GetDepth(descendantTwo, topAncestor);
        return depthOne > depthTwo ?
            BacktrackTree(descendantOne, descendantTwo, depthOne - depthTwo) :
            BacktrackTree(descendantTwo, descendantOne, depthTwo - depthOne);
    }

    public static int GetDepth(AncestralTree? descendant, AncestralTree? ancestor)
    {
        var depth = 0;
        while (descendant != ancestor)
        {
            depth++;
            descendant = descendant?.Ancestor;
        }
        return depth;
    }
    public static AncestralTree? BacktrackTree(AncestralTree? lower, AncestralTree? higher, int diff)
    {
        while (diff > 0)
        {
            lower = lower?.Ancestor;
            diff--;
        }
        while (lower != higher)
        {
            lower = lower?.Ancestor;
            higher = higher?.Ancestor;
        }
        return lower;
    }
    public class AncestralTree(char name)
    {
        public char Name { get; } = name;
        public AncestralTree? Ancestor { get; private set; } = null;

        // This method is for testing only.
        public void AddAsAncestor(AncestralTree[] descendants)
        {
            foreach (var descendant in descendants)
                descendant.Ancestor = this;
        }
    }
}
