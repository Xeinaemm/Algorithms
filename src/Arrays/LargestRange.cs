namespace Algorithms.Arrays;
public static class LargestRange
{
    // O(n) time | O(n) space
    public static int[] First(int[] array)
    {
        var hashSet = new HashSet<int>(array);
        var result = new int[2];
        var diff = 0;
        foreach (var number in array)
        {
            if (!hashSet.Contains(number))
                continue;
            var lowestNumber = number - 1;
            var highestNumber = number + 1;
            _ = hashSet.Remove(number);
            while (hashSet.Contains(lowestNumber))
            {
                _ = hashSet.Remove(lowestNumber);
                lowestNumber--;
            }
            while (hashSet.Contains(highestNumber))
            {
                _ = hashSet.Remove(highestNumber);
                highestNumber++;
            }
            var currentDiff = highestNumber - lowestNumber;
            if (currentDiff > diff)
            {
                diff = currentDiff;
                result = [lowestNumber + 1, highestNumber - 1];
            }
        }
        return result;
    }
}
