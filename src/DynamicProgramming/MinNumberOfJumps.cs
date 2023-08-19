namespace Algorithms.DynamicProgramming;
public static class MinNumberOfJumps
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        if (array.Length == 1)
            return 0;
        var jumps = 0;
        var maxReach = array[0];
        var steps = array[0];
        for (var i = 1; i < array.Length - 1; i++)
        {
            maxReach = Math.Max(maxReach, array[i] + i);
            steps--;
            if (steps == 0)
            {
                jumps++;
                steps = maxReach - i;
            }
        }
        return jumps + 1;
    }
}
