namespace Algorithms.DynamicProgramming;
public static class NumberOfWaysToTraverseGraph
{
    // O(n + m) time | O(1) space
    public static int First(int width, int height)
        => Factorial(width - 1 + height - 1) / (Factorial(width - 1) * Factorial(height - 1));

    // O(nm) time | O(nm) space
    public static int Second(int width, int height)
    {
        var numberOfWays = new int[height + 1, width + 1];
        for (var i = 1; i <= width; i++)
            for (var j = 1; j <= height; j++)
                numberOfWays[j, i] = i == 1 || j == 1 ?
                    1 :
                    numberOfWays[j, i - 1] + numberOfWays[j - 1, i];
        return numberOfWays[height, width];
    }

    public static int Factorial(int num)
    {
        var result = 1;
        for (var i = 2; i <= num; i++)
            result *= i;
        return result;
    }
}
