namespace Algorithms.Arrays;

public static class ThreeNumberSum
{
    // O(n^2) time | O(n) space
    public static List<int[]> First(int[] array, int targetSum)
    {
        Array.Sort(array);
        var result = new List<int[]>();
        for (var i = 0; i < array.Length - 2; i++)
        {
            var leftPtr = i + 1;
            var rightPtr = array.Length - 1;
            while (leftPtr < rightPtr)
            {
                var currentSum = array[i] + array[leftPtr] + array[rightPtr];
                if (targetSum == currentSum)
                {
                    result.Add([array[i], array[leftPtr], array[rightPtr]]);
                    rightPtr--;
                    leftPtr++;
                }
                else if (currentSum < targetSum)
                    leftPtr++;
                else
                    rightPtr--;
            }
        }
        return result;
    }
}
