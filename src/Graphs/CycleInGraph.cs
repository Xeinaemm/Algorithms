namespace Algorithms.Graphs;
public static class CycleInGraph
{
    // O(v + e) time | O(v) space
    public static bool First(int[][] edges)
    {
        var colors = new int[edges.Length];
        Array.Fill(colors, 0);
        for (var node = 0; node < edges.Length; node++)
            if (DFSCycleExists(ref colors, ref edges, node))
                return true;
        return false;
    }

    private static bool DFSCycleExists(ref int[] colors, ref int[][] edges, int node)
    {
        colors[node] = 1;
        foreach (var neighbor in edges[node])
            if (colors[neighbor] == 2)
                continue;
            else if (colors[neighbor] == 1)
                return true;
            else if (DFSCycleExists(ref colors, ref edges, neighbor))
                return true;

        colors[node] = 2;
        return false;
    }
}
