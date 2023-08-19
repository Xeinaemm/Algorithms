namespace Algorithms.Graphs;
public static class TwoColorable
{
    // O(v + e) time | O(v) space
    public static bool First(int[][] edges)
    {
        var colors = new int[edges.Length];
        colors[0] = 1;
        var stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count > 0)
        {
            var node = stack.Pop();
            foreach (var connection in edges[node])
                if (colors[connection] == 0)
                {
                    colors[connection] = colors[node] == 1 ? 2 : 1;
                    stack.Push(connection);
                }
                else if (colors[connection] == colors[node])
                    return false;
        }

        return true;
    }
}
