namespace Algorithms.Strings;
public static class LongestPalindromicSubstring
{
    // O(n^2) time | O(1) space
    public static string First(string str)
    {
        var result = str[..1];
        for (var i = 1; i < str.Length - 1; i++)
        {
            if (str[i - 1] == str[i + 1])
                result = CalculatePalindrom(str, result, i - 1, i + 1);
            if (str[i] == str[i + 1])
                result = CalculatePalindrom(str, result, i, i + 1);
            if (str[i - 1] == str[i])
                result = CalculatePalindrom(str, result, i - 1, i);
        }
        return result;
    }

    public static string CalculatePalindrom(string str, string result, int leftPtr, int rightPtr)
    {
        while (leftPtr >= 0 && rightPtr < str.Length && str[leftPtr] == str[rightPtr])
        {
            leftPtr--;
            rightPtr++;
        }
        var palindrom = str.Substring(leftPtr + 1, rightPtr - leftPtr - 1);
        return palindrom.Length > result.Length ? palindrom : result;
    }
}
