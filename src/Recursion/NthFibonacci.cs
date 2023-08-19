namespace Algorithms.Recursion;

public static class NthFibonacci
{
    // O(2^n) time | O(n) space
    public static int First(int n) =>
        n <= 2 ? n - 1 : First(n - 1) + First(n - 2);

    // O(n) time | O(n) space
    public static int Second(int n)
    {
        var storedResults = new int[n + 1];
        return FibRecursionMemoize(n, storedResults);
    }

    // O(n) time | O(1) space
    public static int Third(int n)
    {
        int previous = 0, current = 1;
        for (var i = 0; i < n; i++)
            (previous, current) = (current, previous + current);
        return previous;
    }

    public static int FibRecursionMemoize(int n, int[] storedResults)
    {
        if (n <= 2)
            return n - 1;
        else if (storedResults.ElementAtOrDefault(n) != 0)
            return storedResults[n];
        storedResults[n] = FibRecursionMemoize(n - 1, storedResults) + FibRecursionMemoize(n - 2, storedResults);
        return storedResults[n];
    }
}
