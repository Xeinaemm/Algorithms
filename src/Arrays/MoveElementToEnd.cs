namespace Algorithms.Arrays;

public static class MoveElementToEnd
{
    // O(n) time | O(1) space
    public static List<int> First(List<int> array, int toMove)
    {
        var leftPtr = 0;
        var rightPtr = array.Count - 1;
        while (leftPtr < rightPtr && array.Count != 0)
        {
            while (array[rightPtr] == toMove && leftPtr < rightPtr)
                rightPtr--;
            while (array[leftPtr] != toMove && leftPtr < rightPtr)
                leftPtr++;

            (array[leftPtr], array[rightPtr]) = (array[rightPtr], array[leftPtr]);
        }
        return array;
    }
}
