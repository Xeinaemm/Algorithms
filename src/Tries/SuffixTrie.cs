namespace Algorithms.Tries;

public class TrieNode
{
    public Dictionary<char, TrieNode> Children { get; } = new();
}

public class SuffixTrie
{
    public TrieNode Root { get; } = new();
    public char EndSymbol { get; } = '*';

    public SuffixTrie(string str) => PopulateSuffixTrieFrom(str);

    // O(n^2) time | O(n^2) space
    public void PopulateSuffixTrieFrom(string str)
    {
        for (var i = 0; i < str.Length; i++)
        {
            var node = Root;
            for (var j = i; j < str.Length; j++)
            {
                var letter = str[j];
                if (!node.Children.ContainsKey(letter))
                    node.Children.Add(letter, new TrieNode());
                node = node.Children[letter];
            }
            node.Children[EndSymbol] = null;
        }
    }

    // O(n) time | O(1) space
    public bool Contains(string str)
    {
        var node = Root;
        for (var i = 0; i < str.Length; i++)
        {
            var letter = str[i];
            if (!node.Children.ContainsKey(letter))
                return false;
            node = node.Children[letter];
        }
        return node.Children.ContainsKey(EndSymbol);
    }
}
