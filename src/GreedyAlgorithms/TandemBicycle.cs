namespace Algorithms.GreedyAlgorithms;

public static class TandemBicycle
{
    // O(nlog(n)) time | O(1) space
    public static int First(int[] redShirtSpeeds, int[] blueShirtSpeeds, bool fastest)
    {
        Array.Sort(redShirtSpeeds);

        if (fastest)
            Array.Sort(blueShirtSpeeds, (a, b) => b.CompareTo(a));
        else
            Array.Sort(blueShirtSpeeds);

        var totalSpeed = 0;
        for (var i = 0; i < redShirtSpeeds.Length; i++)
            totalSpeed += Math.Max(redShirtSpeeds[i], blueShirtSpeeds[i]);

        return totalSpeed;
    }
}
