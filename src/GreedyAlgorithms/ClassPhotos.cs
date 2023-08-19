namespace Algorithms.GreedyAlgorithms;

public static class ClassPhotos
{
    // O(nlog(n)) time | O(1) space
    public static bool First(List<int> redShirtHeights, List<int> blueShirtHeights)
    {
        redShirtHeights.Sort();
        blueShirtHeights.Sort();
        var count = redShirtHeights.Count - 1;
        var isRedTaller = redShirtHeights[count] > blueShirtHeights[count];
        for (var i = 0; i <= count; i++)
            if (isRedTaller)
                if (redShirtHeights[i] <= blueShirtHeights[i])
                    return false;
                else if (blueShirtHeights[i] <= redShirtHeights[i])
                    return false;
        return true;
    }
}
