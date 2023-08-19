namespace Algorithms.Strings;

public static class GenerateDocument
{
    // O(n + m) time | O(c) space
    public static bool First(string characters, string document)
    {
        var chars = new Dictionary<char, int>();
        foreach (var c in characters)
            chars[c] = chars.GetValueOrDefault(c, 0) + 1;

        foreach (var c in document)
        {
            if (!chars.ContainsKey(c) || chars[c] == 0)
                return false;

            chars[c] = chars[c] - 1;
        }
        return true;
    }
}
