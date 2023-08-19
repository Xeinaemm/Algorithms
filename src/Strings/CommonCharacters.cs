namespace Algorithms.Strings;

public static class CommonCharacters
{
    // O(nm) time | O(m) space, where m is the longest string
    public static char[] First(string[] strings)
    {
        var potentialCommonChars = strings[0].ToCharArray();
        for (var i = 1; i < strings.Length; i++)
            if (strings[i].Length < potentialCommonChars.Length)
                potentialCommonChars = strings[i].ToCharArray();

        for (var i = 0; i < strings.Length; i++)
            potentialCommonChars = Intersect(strings[i].ToCharArray(), potentialCommonChars);
        return potentialCommonChars;
    }

    public static char[] Intersect(char[] first, char[] second)
    {
        var set = new HashSet<char>(second);
        return first.Where(set.Remove).ToArray();
    }
}
