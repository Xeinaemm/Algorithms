namespace Algorithms.GreedyAlgorithms;
public static class MinimumWaitingTime
{
    // O(nlog(n)) time | O(1) space
    public static int First(int[] queries)
    {
        Array.Sort(queries);
        var waitingTime = 0;
        for (var i = 0; i < queries.Length; i++)
        {
            var queriesLeft = queries.Length - (i + 1);
            waitingTime += queries[i] * queriesLeft;
        }
        return waitingTime;
    }
}
