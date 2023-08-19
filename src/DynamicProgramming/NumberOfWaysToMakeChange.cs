namespace Algorithms.DynamicProgramming;
public static class NumberOfWaysToMakeChange
{
    // O(nd) time | O(n) space
    public static int First(int n, int[] denoms)
    {
        var ways = new int[n + 1];
        ways[0] = 1;
        foreach (var denom in denoms)
            for (var amount = 1; amount < n + 1; amount++)
                if (denom <= amount)
                    ways[amount] += ways[amount - denom];
        return ways[n];
    }
}
