namespace Algorithms.Arrays;
public static class SmallestDifference
{
    // O(n^2) time | O(1) space
    public static int[] First(int[] arrayOne, int[] arrayTwo)
    {
        Array.Sort(arrayOne);
        Array.Sort(arrayTwo);
        var ptrOne = 0;
        var ptrTwo = 0;
        var distance = int.MaxValue;
        var result = new int[2];
        while (ptrOne < arrayOne.Length && ptrTwo < arrayTwo.Length)
        {
            var first = arrayOne[ptrOne];
            var second = arrayTwo[ptrTwo];
            if (first < second)
                ptrOne++;
            else if (first > second)
                ptrTwo++;
            else
                return [first, second];

            var newDistance = Math.Abs(first - second);
            if (newDistance < distance)
            {
                distance = newDistance;
                result = [first, second];
            }
        }
        return result;
    }
}
