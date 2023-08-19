namespace Algorithms.Stacks;
public static class BalancedBrackets
{
    // O(n) time | O(n) space
    public static bool First(string str)
    {
        var stack = new Stack<char>();
        var openingBrackets = new HashSet<char>("([{");
        var closingBrackets = new HashSet<char>("}])");
        var brackets = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };
        foreach (var c in str)
        {
            if (openingBrackets.Contains(c))
                stack.Push(c);
            else if (closingBrackets.Contains(c))
                if (stack.Count == 0)
                    return false;
                else if (stack.Peek() == brackets[c])
                    _ = stack.Pop();
                else
                    return false;
        }

        return stack.Count == 0;
    }
}
