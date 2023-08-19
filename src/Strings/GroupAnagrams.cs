namespace Algorithms.Strings;
public static class GroupAnagrams
{
    // O(wn*log(n)) time | O(wn) space, where w is the number of words and n is the length of the longest word
    public static List<List<string>> First(List<string> words)
    {
        var result = new Dictionary<string, List<string>>();
        foreach (var word in words)
        {
            var sortedWord = string.Concat(word.OrderBy(c => c));
            if (result.ContainsKey(sortedWord))
                result[sortedWord].Add(word);
            else
                result[sortedWord] = new List<string> { word };
        }
        return result.Values.ToList();
    }
}
