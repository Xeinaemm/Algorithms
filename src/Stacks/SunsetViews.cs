namespace Algorithms.Stacks;
public static class SunsetViews
{
    // O(n) time | O(n) space
    public static List<int> First(int[] buildings, string direction)
    {
        var result = new List<int>();
        var idx = buildings.Length - 1;
        var step = -1;
        var maxHeight = 0;
        if (direction == "WEST")
        {
            idx = 0;
            step = 1;
        }

        while (idx >= 0 && idx < buildings.Length)
        {
            var buildingHeight = buildings[idx];

            if (buildingHeight > maxHeight)
                result.Add(idx);
            maxHeight = Math.Max(maxHeight, buildingHeight);
            idx += step;
        }
        if (direction == "EAST")
            result.Reverse();
        return result;
    }
}
