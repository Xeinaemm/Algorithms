using Algorithms.Structures;

namespace Algorithms.BinaryTrees;
public static class FindNodesDistanceK
{
    // O(n) time | O(n) space
    public static List<int> First(BinaryTree tree, int target, int k)
    {
        var parents = new Dictionary<int, BinaryTree>();
        GetParents(tree, parents, null);
        var targetNode = GetNodeFromValue(target, tree, parents);
        return BfsNodesDistanceK(targetNode, parents, k);
    }

    // O(n) time | O(n) space
    public static List<int> Second(BinaryTree? tree, int target, int k)
    {
        var distanceK = new List<int>();
        FindDistance(tree, target, k, distanceK);
        return distanceK;
    }

    public static int FindDistance(BinaryTree? node, int target, int k, List<int> distanceK)
    {
        if (node == null)
            return -1;
        if (node.Value == target)
        {
            AddSubtree(node, 0, k, distanceK);
            return 1;
        }
        var left = FindDistance(node.Left, target, k, distanceK);
        var right = FindDistance(node.Right, target, k, distanceK);

        if (left == k || right == k)
            distanceK.Add(node.Value);
        if (left != -1)
        {
            AddSubtree(node.Right, left + 1, k, distanceK);
            return left + 1;
        }
        if (right != -1)
        {
            AddSubtree(node.Left, right + 1, k, distanceK);
            return right + 1;
        }
        return -1;
    }

    private static void AddSubtree(BinaryTree? node, int distance, int k, List<int> distanceK)
    {
        if (node == null)
            return;
        if (distance == k)
            distanceK.Add(node.Value);
        else
        {
            AddSubtree(node.Left, distance + 1, k, distanceK);
            AddSubtree(node.Right, distance + 1, k, distanceK);
        }
    }

    private static List<int> BfsNodesDistanceK(BinaryTree? targetNode, Dictionary<int, BinaryTree> parents, int k)
    {
        var queue = new Queue<Tuple<BinaryTree, int>>();
        queue.Enqueue(new Tuple<BinaryTree, int>(targetNode, 0));
        var seen = new HashSet<int>(targetNode.Value)
        {
            targetNode.Value
        };

        while (queue.Count > 0)
        {
            (BinaryTree currentNode, int distance) = queue.Dequeue();
            if (distance == k)
            {
                var distanceK = new List<int>();
                foreach (var pair in queue)
                    distanceK.Add(pair.Item1.Value);
                distanceK.Add(currentNode.Value);
                return distanceK;
            }
            var connectedNodes = new List<BinaryTree>()
            {
                currentNode.Left,
                currentNode.Right,
                parents[currentNode.Value]
            };
            foreach (var node in connectedNodes)
            {
                if (node == null)
                    continue;
                if (seen.Contains(node.Value))
                    continue;
                _ = seen.Add(node.Value);
                queue.Enqueue(new Tuple<BinaryTree, int>(node, distance + 1));
            }
        }
        return new List<int>();
    }

    private static BinaryTree? GetNodeFromValue(int value, BinaryTree tree, Dictionary<int, BinaryTree> parents)
    {
        if (tree.Value == value)
            return tree;
        var parent = parents[value];
        return parent.Left != null && parent.Left.Value == value ? parent.Left : parent.Right;
    }

    private static void GetParents(BinaryTree? node, Dictionary<int, BinaryTree> parents, BinaryTree? parent)
    {
        if (node != null)
        {
            parents[node.Value] = parent;
            GetParents(node.Left, parents, node);
            GetParents(node.Right, parents, node);
        }
    }
}
