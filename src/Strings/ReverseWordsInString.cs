namespace Algorithms.Strings;
public static class ReverseWordsInString
{
    // O(n) time | O(n) space
    public static string First(string str)
    {
        var words = new List<string>();
        var wordStart = 0;
        for (var i = 0; i < str.Length; i++)
            if (str[i] == ' ')
            {
                words.Add(str[wordStart..i]);
                words.Add(" ");
                wordStart = i + 1;
            }

        words.Add(str[wordStart..]);
        words.Reverse();
        return string.Join("", words);
    }
}
