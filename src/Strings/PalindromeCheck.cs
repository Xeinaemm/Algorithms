namespace Algorithms.Strings;
public static class PalindromeCheck
{
    // O(n) time | O(1) space
    public static bool IsPalindrome(string str)
    {
        var leftPtr = 0;
        var rightPtr = str.Length - 1;
        while (leftPtr < rightPtr)
        {
            if (str[leftPtr] != str[rightPtr])
                return false;
            leftPtr++;
            rightPtr--;
        }
        return true;
    }
}
