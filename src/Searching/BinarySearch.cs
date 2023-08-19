namespace Algorithms.Searching;

public static class BinarySearch
{
    // O(log(n)) time | O(1) space
    // Start from the middle and choose left or right subarray until you find a number.
    public static int First(int[] array, int target)
    {
        var leftPtr = 0;
        var rightPtr = array.Length - 1;
        while (leftPtr <= rightPtr)
        {
            var middle = (leftPtr + rightPtr) / 2;
            if (target == array[middle])
                return middle;
            else if (target > array[middle])
                leftPtr = middle + 1;
            else
                rightPtr = middle - 1;
        }
        return -1;
    }
}
