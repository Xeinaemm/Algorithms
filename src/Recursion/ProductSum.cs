namespace Algorithms.Recursion;
public static class ProductSum
{
    // O(n) time | O(h) space
    public static int First(List<object> array, int depth = 1)
    {
        var totalSum = 0;
        foreach (var item in array)
            totalSum += item is int value
                ? value
                : First(item as List<object>, depth + 1);

        return totalSum * depth;
    }
}
