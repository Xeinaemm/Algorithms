namespace Algorithms.FamousAlgorithms;
public class UnionFind
{
    private readonly Dictionary<int, int> parents = new();
    private readonly Dictionary<int, int> ranks = new();

    // O(1) time | O(1) space
    public void CreateSet(int value)
    {
        parents[value] = value;
        ranks[value] = 0;
    }

    // O(α(n)) approx. O(1) time | O(α(n)) approx. O(1) space
    public int? Find(int value)
    {
        if (!parents.ContainsKey(value))
            return null;
        if (value != parents[value])
            parents[value] = (int)Find(parents[value]);

        return parents[value];
    }

    // O(α(n)) approx. O(1) time | O(α(n)) approx. O(1) space
    public void Union(int valueOne, int valueTwo)
    {
        if (!parents.ContainsKey(valueOne) || !parents.ContainsKey(valueTwo))
            return;
        var valueOneRoot = (int)Find(valueOne);
        var valueTwoRoot = (int)Find(valueTwo);
        if (ranks[valueOneRoot] < ranks[valueTwoRoot])
            parents[valueOneRoot] = valueTwoRoot;
        else if (ranks[valueOneRoot] > ranks[valueTwoRoot])
            parents[valueTwoRoot] = valueOneRoot;
        else
        {
            parents[valueTwoRoot] = valueOneRoot;
            ranks[valueOneRoot] = ranks[valueOneRoot] + 1;
        }
    }
}
