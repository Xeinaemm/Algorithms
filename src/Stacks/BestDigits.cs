namespace Algorithms.Stacks;
public static class BestDigits
{
    // O(n) time | O(n) space
    public static string First(string number, int numDigits)
    {
        var result = new Stack<char>();
        foreach (var digit in number)
        {
            while (numDigits > 0 && result.Count > 0 && result.Peek() < digit)
            {
                numDigits--;
                _ = result.Pop();
            }
            result.Push(digit);
        }
        while (numDigits > 0)
        {
            numDigits--;
            _ = result.Pop();
        }
        return new string(result.Reverse().ToArray());
    }
}
