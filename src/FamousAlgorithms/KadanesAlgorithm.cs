namespace Algorithms.FamousAlgorithms;
public static class KadanesAlgorithm
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        var kadanesMax = 0;
        var currentMax = int.MinValue;
        for (var i = 0; i < array.Length; i++)
        {
            kadanesMax = Math.Max(kadanesMax + array[i], array[i]);
            currentMax = Math.Max(currentMax, kadanesMax);
        }
        return currentMax;
    }
}
