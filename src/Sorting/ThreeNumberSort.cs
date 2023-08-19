namespace Algorithms.Sorting;
public static class ThreeNumberSort
{
    // O(n) time | O(1) space
    public static int[] First(int[] array, int[] order)
    {
        var firstValue = order[0];
        var secondtValue = order[1];
        var first = 0;
        var second = 0;
        var third = array.Length - 1;
        while (second <= third)
            if (array[second] == firstValue)
            {
                (array[second], array[first]) = (array[first], array[second]);
                first++;
                second++;
            }
            else if (array[second] == secondtValue)
                second++;
            else
            {
                (array[third], array[second]) = (array[second], array[third]);
                third--;
            }
        return array;
    }
}
