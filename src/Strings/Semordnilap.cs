namespace Algorithms.Strings;
public static class Semordnilap
{
    // O(nm) time | O(nm) space
    public static List<List<string>> First(string[] words)
    {
        var wordsSet = new HashSet<string>(words);
        var result = new List<List<string>>();
        while (wordsSet.Count != 0)
        {
            var word = wordsSet.First();
            var wordReversed = new string(wordsSet.First().Reverse().ToArray());
            if (wordsSet.Contains(wordReversed) && word != wordReversed)
            {
                result.Add(new List<string>() { word, wordReversed });
                _ = wordsSet.Remove(word);
                _ = wordsSet.Remove(wordReversed);
            }
            else
                _ = wordsSet.Remove(word);
        }
        return result;
    }
}
