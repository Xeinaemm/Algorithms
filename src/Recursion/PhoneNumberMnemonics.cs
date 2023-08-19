namespace Algorithms.Recursion;
public class PhoneNumberMnemonics
{
    private static readonly Dictionary<char, string[]> DigitLetters = new()
    {
      {'0', new string [] { "0" }},
      {'1', new string [] { "1" }},
      {'2', new string [] { "a", "b", "c" }},
      {'3', new string [] { "d", "e", "f" }},
      {'4', new string [] { "g", "h", "i" }},
      {'5', new string [] { "j", "k", "l" }},
      {'6', new string [] { "m", "n", "o" }},
      {'7', new string [] { "p", "q", "r", "s" }},
      {'8', new string [] { "t", "u", "v" }},
      {'9', new string [] { "w", "x", "y", "z" }}
    };

    // O(4^n * n) time | O(4^n * n) space
    public List<string> First(string phoneNumber)
    {
        var currentMnemonic = new string[phoneNumber.Length];
        Array.Fill(currentMnemonic, "0");
        var result = new List<string>();
        GetMnemonics(0, phoneNumber, currentMnemonic, result);
        return result;
    }

    public void GetMnemonics(int i, string phoneNumber, string[] currentMnemonic, List<string> result)
    {
        if (i == phoneNumber.Length)
            result.Add(string.Join("", currentMnemonic));
        else
            foreach (var letter in DigitLetters[phoneNumber[i]])
            {
                currentMnemonic[i] = letter;
                GetMnemonics(i + 1, phoneNumber, currentMnemonic, result);
            }
    }
}
