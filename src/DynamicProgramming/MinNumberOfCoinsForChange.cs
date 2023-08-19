namespace Algorithms.DynamicProgramming;
public static class MinNumberOfCoinsForChange
{
    // O(nd) time | O(n) space
    public static int First(int n, int[] denoms)
    {
        var numOfCoins = new int[n + 1];
        Array.Fill(numOfCoins, int.MaxValue);
        numOfCoins[0] = 0;
        foreach (var denom in denoms)
            for (var amount = 0; amount < numOfCoins.Length; amount++)
                if (denom <= amount)
                    numOfCoins[amount] = numOfCoins[amount - denom] == int.MaxValue ?
                        Math.Min(numOfCoins[amount], numOfCoins[amount - denom]) :
                        Math.Min(numOfCoins[amount], numOfCoins[amount - denom] + 1);
        return numOfCoins[n] != int.MaxValue ?
               numOfCoins[n] :
               -1;
    }
}
