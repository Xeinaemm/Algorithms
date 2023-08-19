using System.Text;

namespace Algorithms.Strings;
public static class ValidIPAddresses
{
    // O(1) time | O(1) space
    public static List<string> First(string str)
    {
        var result = new List<string>();
        for (var i = 1; i < Math.Min(str.Length, 4); i++)
        {
            var currentIpParts = new string[] { "", "", "", "" };
            currentIpParts[0] = str[..i];
            if (!IsValidPart(currentIpParts[0]))
                continue;
            for (var j = i + 1; j < i + Math.Min(str.Length - i, 4); j++)
            {
                currentIpParts[1] = str[i..j];
                if (!IsValidPart(currentIpParts[1]))
                    continue;
                for (var k = j + 1; k < j + Math.Min(str.Length - j, 4); k++)
                {
                    currentIpParts[2] = str[j..k];
                    currentIpParts[3] = str[k..];
                    if (IsValidPart(currentIpParts[2]) && IsValidPart(currentIpParts[3]))
                        result.Add(Join(currentIpParts));
                }
            }
        }
        return result;
    }

    public static bool IsValidPart(string str)
    {
        var isInt = int.Parse(str);
        return isInt <= 255 && str.Length == isInt.ToString().Length;
    }

    public static string Join(string[] strings)
    {
        var sb = new StringBuilder();
        for (var i = 0; i < strings.Length; i++)
        {
            sb.Append(strings[i]);
            if (i < strings.Length - 1)
                sb.Append('.');
        }
        return sb.ToString();
    }
}
