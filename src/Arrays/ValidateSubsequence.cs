namespace Algorithms.Arrays;

public static class ValidateSubsequence
{
    // O(n) time | O(1) space
    public static bool First(List<int> array, List<int> sequence)
    {
        var subsequencePointer = 0;
        for (var i = 0; i < array.Count; i++)
        {
            var mainNumber = array[i];
            var subsequenceNumber = sequence[subsequencePointer];
            if (mainNumber == subsequenceNumber)
            {
                if (subsequencePointer == sequence.Count - 1)
                    return true;

                subsequencePointer++;
            }
        }

        return false;
    }
}
