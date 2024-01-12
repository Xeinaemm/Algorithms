namespace Algorithms.Arrays;

public static class TwoNumberSum
{
    // O(n) time | O(n) space
    public static int[] Second(int[] array, int targetSum)
    {
        var visited = new HashSet<int>();
        for (var i = 0; i < array.Length; i++)
        {
            var firstNumber = array[i];
            var containsSecondNumber = visited.TryGetValue(targetSum - firstNumber, out var secondNumber);
            if (containsSecondNumber)
                return [firstNumber, secondNumber];
            else
                _ = visited.Add(firstNumber);
        }
        return Array.Empty<int>();
    }

    // O(nlog(n)) time | O(1) space
    public static int[] Third(int[] array, int targetSum)
    {
        Array.Sort(array);
        var leftPointer = 0;
        var rightPointer = array.Length - 1;
        while (leftPointer != rightPointer)
        {
            var leftNumber = array[leftPointer];
            var rightNumber = array[rightPointer];
            var numbersSum = leftNumber + rightNumber;
            if (numbersSum == targetSum)
                return [leftNumber, rightNumber];
            if (numbersSum > targetSum)
                rightPointer--;
            if (numbersSum < targetSum)
                leftPointer++;
        }
        return Array.Empty<int>();
    }
}
