namespace Algorithms.Arrays;
public static class ArrayOfProducts
{
    // O(n) time | O(n) space
    // Multiply from the left and then right and combine the result
    public static int[] First(int[] array)
    {
        var result = new int[array.Length];
        var leftResult = 1;
        for (var i = 0; i < array.Length; i++)
        {
            result[i] = leftResult;
            leftResult *= array[i];
        }
        var rightResult = 1;
        for (var i = array.Length - 1; i >= 0; i--)
        {
            result[i] *= rightResult;
            rightResult *= array[i];
        }
        return result;
    }
}
