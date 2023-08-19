namespace Algorithms.Strings;
public static class MinimumCharactersForWords
{
    // O(n * l) time | O(c) space, where n is number of words, l is longest word and c is unique characters
    public static char[] First(string[] words)
    {
        var ranks = new Dictionary<char, int>();
        foreach (var word in words)
        {
            var letterRanks = new Dictionary<char, int>();
            foreach (var letter in word)
                letterRanks[letter] = letterRanks.ContainsKey(letter) ? letterRanks[letter] + 1 : 1;

            foreach (var rank in letterRanks.Keys)
                if (ranks.ContainsKey(rank) && letterRanks[rank] > ranks[rank] || !ranks.ContainsKey(rank))
                    ranks[rank] = letterRanks[rank];
        }
        var result = new List<char>();
        foreach (var rank in ranks)
            for (var i = 0; i < rank.Value; i++)
                result.Add(rank.Key);
        return result.ToArray();
    }
}
