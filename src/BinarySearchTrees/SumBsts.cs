using Algorithms.Structures;

namespace Algorithms.BinarySearchTrees;
public static class SumBsts
{
    // O(n) time | O(h) space where h is height of tree
    public static int First(BinaryTree tree) =>
      GetTreeInfo(tree).TotalSum;

    public static TreeInfo GetTreeInfo(BinaryTree? tree)
    {
        if (tree == null)
            return new TreeInfo();
        var left = GetTreeInfo(tree.Left);
        var right = GetTreeInfo(tree.Right);
        var isBstProp = tree.Value > left.MaxValue && tree.Value <= right.MinValue;
        var isBst = isBstProp && left.IsBst && right.IsBst;
        var maxValue = Math.Max(tree.Value, Math.Max(left.MaxValue, right.MaxValue));
        var minValue = Math.Min(tree.Value, Math.Min(left.MinValue, right.MinValue));
        var bstSum = 0;
        var bstSize = 0;
        var totalSum = left.TotalSum + right.TotalSum;
        if (isBst)
        {
            bstSum = tree.Value + left.BstSum + right.BstSum;
            bstSize = 1 + left.BstSize + right.BstSize;
            if (bstSize >= 3)
                totalSum = bstSum;
        }
        return new TreeInfo(isBst, minValue, maxValue, bstSum, bstSize, totalSum);
    }

    public class TreeInfo
    {
        public bool IsBst { get; private set; }
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }
        public int BstSum { get; private set; }
        public int BstSize { get; private set; }
        public int TotalSum { get; private set; }

        public TreeInfo(
            bool isBst = true,
            int minValue = int.MaxValue,
            int maxValue = int.MinValue,
            int bstSum = 0,
            int bstSize = 0,
            int totalSum = 0)
        {
            IsBst = isBst;
            MinValue = minValue;
            MaxValue = maxValue;
            BstSum = bstSum;
            BstSize = bstSize;
            TotalSum = totalSum;
        }
    }
}
