namespace Algorithms.Recursion;
public static class Powerset
{
    // O(n^2 * n) time | O(n^2 * n) space
    public static List<List<int>> First(List<int> array)
    {
        var subsets = new List<List<int>>
        {
            new List<int>()
        };
        foreach (var element in array)
        {
            var count = subsets.Count;
            for (var i = 0; i < count; i++)
                subsets.Add(new List<int>(subsets[i]) { element });
        }

        return subsets;
    }
}
