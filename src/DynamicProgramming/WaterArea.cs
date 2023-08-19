namespace Algorithms.DynamicProgramming;
public static class WaterArea
{
    // O(n) time | O(1) space
    public static int First(int[] heights)
    {
        if (heights.Length == 0)
            return 0;
        var leftPtr = 0;
        var rightPtr = heights.Length - 1;
        var leftMax = heights[leftPtr];
        var rightMax = heights[rightPtr];
        var surfaceArea = 0;
        while (leftPtr < rightPtr)
            if (heights[leftPtr] < heights[rightPtr])
            {
                leftPtr++;
                leftMax = Math.Max(leftMax, heights[leftPtr]);
                surfaceArea += leftMax - heights[leftPtr];
            }
            else
            {
                rightPtr--;
                rightMax = Math.Max(rightMax, heights[rightPtr]);
                surfaceArea += rightMax - heights[rightPtr];
            }

        return surfaceArea;
    }
}
