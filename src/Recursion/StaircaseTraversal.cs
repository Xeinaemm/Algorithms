namespace Algorithms.Recursion;
public static class StaircaseTraversal
{
    // O(n) time | O(n) space
    public static int First(int height, int maxSteps)
    {
        var currentWays = 0;
        var result = new List<int>
        {
            1
        };

        for (var i = 0; i < height; i++)
        {
            // Window sliding technique.
            if (i - maxSteps >= 0)
                currentWays -= result[i - maxSteps];
            currentWays += result[i];
            result.Add(currentWays);
        }
        return result[height];
    }
}
