using System.Text;

namespace Algorithms.Strings;
public static class LengthEncoding
{
    // O(n) time | O(n) space
    public static string First(string str)
    {
        var result = new StringBuilder();
        var length = 1;
        for (var i = 1; i < str.Length; i++)
        {
            if (str[i - 1] == str[i])
            {
                length++;
                continue;
            }
            result.Append(length);
            result.Append(str[i - 1]);
            length = 1;
        }
        result.Append(length);
        result.Append(str[^1]);
        return result.ToString();
    }
}
