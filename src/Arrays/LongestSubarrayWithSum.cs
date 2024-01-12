namespace Algorithms.Arrays;
public static class LongestSubarrayWithSum
{
    // O(n) time | O(1) space
    public static int[] First(int[] array, int targetSum)
    {
        var result = Array.Empty<int>();
        var startingPtr = 0;
        var endingPtr = 0;
        var currentSum = 0;
        while (endingPtr < array.Length)
        {
            currentSum += array[endingPtr];
            while (startingPtr < endingPtr && currentSum > targetSum)
            {
                currentSum -= array[startingPtr];
                startingPtr++;
            }
            if (currentSum == targetSum && (result.Length == 0 || result[1] - result[0] < endingPtr - startingPtr))
                result = [startingPtr, endingPtr];
            endingPtr++;
        }
        return result;
    }
}
