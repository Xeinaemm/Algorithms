namespace Algorithms.Arrays;
public static class BestSeat
{
    // O(n) time | O(1) space
    // Create a range with left and right pointers starting from the beginning
    public static int First(int[] seats)
    {
        int bestSeat = -1, maxSpace = 0, leftPtr = 0, rightPtr = 1;
        while (leftPtr != seats.Length - 1)
        {
            while (seats[rightPtr] == 0)
                rightPtr++;
            var newMaxSpace = rightPtr - leftPtr - 1;
            if (newMaxSpace > maxSpace)
            {
                bestSeat = (leftPtr + rightPtr) / 2;
                maxSpace = newMaxSpace;
            }
            leftPtr = rightPtr;
            rightPtr++;
        }
        return bestSeat;
    }
}
