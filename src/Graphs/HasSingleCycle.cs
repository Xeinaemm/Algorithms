namespace Algorithms.Graphs;
public static class HasSingleCycle
{
    // O(n) time | O(1) space
    public static bool First(int[] array)
    {
        var currentIdx = 0;
        for (var i = 1; i <= array.Length; i++)
        {
            var nextIdx = (currentIdx + array[currentIdx]) % array.Length;
            currentIdx = nextIdx >= 0 ? nextIdx : nextIdx + array.Length;
            if (i == array.Length && currentIdx == 0)
                return true;
            else if (i > 1 && currentIdx == 0)
                return false;
        }
        return false;
    }
}
