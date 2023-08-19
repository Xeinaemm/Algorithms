namespace Algorithms.Recursion;
public static class BlackjackProbability
{
    // O(t - s) time | O(t - s) space, where t is the target and s is the starting hand
    public static double First(int target, int startingHand)
    {
        var memoize = new Dictionary<int, double>();
        return Math.Round(CalculateBustProbability(target, startingHand, memoize) * 1000f) / 1000f;
    }

    public static double CalculateBustProbability(int target, int currentHand, Dictionary<int, double> memoize)
    {
        if (memoize.ContainsKey(currentHand))
            return memoize[currentHand];
        if (currentHand > target)
            return 1;
        if (currentHand + 4 >= target)
            return 0;
        var probability = 0.0;
        for (var i = 1; i <= 10; i++)
            probability += .1 * CalculateBustProbability(target, currentHand + i, memoize);
        memoize[currentHand] = probability;
        return probability;
    }
}
