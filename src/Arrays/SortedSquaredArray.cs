namespace Algorithms.Arrays;

public static class SortedSquaredArray
{
    // O(nlog(n)) time | O(n) space
    public static int[] First(int[] array)
    {
        var squares = new int[array.Length];

        for (var i = 0; i < array.Length; i++)
            squares[i] = (int)Math.Pow(array[i], 2);
        Array.Sort(squares);
        return squares;

    }

    // O(n) time | O(n) space
    public static int[] Second(int[] array)
    {
        var sortedSquares = new int[array.Length];
        var leftPointer = 0;
        var rightPointer = array.Length - 1;
        var insertPointer = array.Length - 1;
        if (leftPointer == rightPointer)
            sortedSquares[insertPointer] = (int)Math.Pow(array[leftPointer], 2);
        while (leftPointer != rightPointer)
        {
            var leftNumber = Math.Abs(array[leftPointer]);
            var rightNumber = Math.Abs(array[rightPointer]);
            if (leftNumber > rightNumber)
            {
                sortedSquares[insertPointer] = (int)Math.Pow(leftNumber, 2);
                leftPointer++;
            }
            else
            {
                sortedSquares[insertPointer] = (int)Math.Pow(rightNumber, 2);
                rightPointer--;
            }

            insertPointer--;
            if (insertPointer == 0)
                sortedSquares[insertPointer] = (int)Math.Pow(array[leftPointer], 2);
        }
        return sortedSquares;
    }
}
