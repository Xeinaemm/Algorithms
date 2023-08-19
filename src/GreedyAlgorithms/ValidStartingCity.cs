namespace Algorithms.GreedyAlgorithms;
public static class ValidStartingCity
{
    // O(n) time | O(1) space
    public static int First(int[] distances, int[] fuel, int mpg)
    {
        var idxResult = 0;
        var milesLeft = 0;
        var minGas = 0;
        for (var i = 1; i < distances.Length; i++)
        {
            milesLeft += mpg * fuel[i - 1] - distances[i - 1];
            if (milesLeft < minGas)
            {
                minGas = milesLeft;
                idxResult = i;
            }
        }
        return idxResult;
    }
}
