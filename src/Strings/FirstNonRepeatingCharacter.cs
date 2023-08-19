namespace Algorithms.Strings;

public static class FirstNonRepeatingCharacter
{
    // O(n) time | O(c) space, where c is length of dictionary
    public static int First(string str)
    {
        var chars = new Dictionary<char, int>();
        foreach (var c in str)
            chars[c] = chars.GetValueOrDefault(c, 0) + 1;
        for (var i = 0; i < str.Length; i++)
            if (chars[str[i]] == 1)
                return i;
        return -1;
    }
}
