namespace Algorithms.Arrays;
public static class CountSquares
{
    // O(n^2) time | O(n) space
    public static int First(int[][] points)
    {
        var hashSet = new HashSet<string>(points.Select(x => $"{x[0]:0.0},{x[1]:0.0}"));
        var count = 0;
        foreach (var a in points)
            foreach (var b in points)
            {
                if (a == b)
                    continue;
                (var aX, var aY) = (a[0], a[1]);
                (var bX, var bY) = (b[0], b[1]);
                (var midX, var midY) = ((aX + bX) / 2.0, (aY + bY) / 2.0);
                (var midDistanceX, var midDistanceY) = (aX - midX, aY - midY);
                (var cX, var cY) = (midX + midDistanceY, midY - midDistanceX);
                (var dX, var dY) = (midX - midDistanceY, midY + midDistanceX);
                if (hashSet.Contains($"{cX:0.0},{cY:0.0}") && hashSet.Contains($"{dX:0.0},{dY:0.0}"))
                    count++;
            }

        return count / 4;
    }
}
