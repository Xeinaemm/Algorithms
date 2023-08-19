namespace Algorithms.Recursion;
public static class Permutations
{
    // O(n!n) time | O(n!n) space
    public static List<List<int>> First(List<int> array)
    {
        var permutations = new List<List<int>>();
        GetPermutations(0, array, permutations);
        return permutations;
    }

    private static void GetPermutations(int i, List<int> array, List<List<int>> permutations)
    {
        if (i == array.Count - 1)
            permutations.Add(new List<int>(array));
        else
            for (var j = i; j < array.Count; j++)
            {
                (array[i], array[j]) = (array[j], array[i]);
                GetPermutations(i + 1, array, permutations);
                (array[i], array[j]) = (array[j], array[i]);
            }
    }
}
