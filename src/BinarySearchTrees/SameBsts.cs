namespace Algorithms.BinarySearchTrees;
public static class SameBsts
{
    // O(n^2) time | O(d) space where d is depth of BST
    public static bool First(List<int> arrayOne, List<int> arrayTwo)
        => IsSameBsts(arrayOne, arrayTwo, 0, 0, int.MinValue, int.MaxValue);

    public static bool IsSameBsts(List<int> arrayOne, List<int> arrayTwo, int idxOne, int idxTwo, int minVal, int maxVal)
    {
        if (idxOne == -1 || idxTwo == -1)
            return idxOne == idxTwo;
        if (arrayOne[idxOne] != arrayTwo[idxTwo])
            return false;
        var leftIdxOne = GetIdxOfFirstSmaller(arrayOne, idxOne, minVal);
        var leftIdxTwo = GetIdxOfFirstSmaller(arrayTwo, idxTwo, minVal);
        var rightIdxOne = GetIdxOfFirstBiggerOrEqual(arrayOne, idxOne, maxVal);
        var rightIdxTwo = GetIdxOfFirstBiggerOrEqual(arrayTwo, idxTwo, maxVal);
        var currentValue = arrayOne[idxOne];
        var left = IsSameBsts(arrayOne, arrayTwo, leftIdxOne, leftIdxTwo, minVal, currentValue);
        var right = IsSameBsts(arrayOne, arrayTwo, rightIdxOne, rightIdxTwo, currentValue, maxVal);
        return left && right;
    }

    public static int GetIdxOfFirstSmaller(List<int> array, int startingIdx, int minVal)
    {
        for (var i = startingIdx + 1; i < array.Count; i++)
            if (array[i] < array[startingIdx] && array[i] >= minVal)
                return i;
        return -1;
    }

    public static int GetIdxOfFirstBiggerOrEqual(List<int> array, int startingIdx, int maxVal)
    {
        for (var i = startingIdx + 1; i < array.Count; i++)
            if (array[i] >= array[startingIdx] && array[i] < maxVal)
                return i;
        return -1;
    }
}
