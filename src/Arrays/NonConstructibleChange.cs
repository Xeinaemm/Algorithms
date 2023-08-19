namespace Algorithms.Arrays;

public static class NonConstructibleChange
{
    // O(nlog(n)) time | O(n) space
    public static int First(int[] coins)
    {
        Array.Sort(coins);
        var change = 0;
        for (var i = 0; i < coins.Length; i++)
        {
            if (coins[i] > change + 1)
                return change + 1;
            change += coins[i];
        }
        return change + 1;
    }
}
