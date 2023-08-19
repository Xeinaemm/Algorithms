using System.Text;

namespace Algorithms.Strings;
public static class CaesarCypherEncryptor
{
    // O(n) time | O(n) space
    public static string First(string str, int key)
    {
        var newLetters = new StringBuilder();
        var newKey = key % 26;
        foreach (var letter in str)
        {
            var newLetterCode = letter + newKey;
            var newLetter = newLetterCode <= 122
                ? (char)newLetterCode
                : (char)(96 + (newLetterCode % 122));
            _ = newLetters.Append(newLetter);
        }
        return newLetters.ToString();
    }
}
