namespace Algorithms.Stacks;
public static class ReversePolishNotation
{
    // O(n) time | O(n) space
    public static int First(string[] tokens)
    {
        var stack = new Stack<int>();
        foreach (var token in tokens)
        {
            var isInt = int.TryParse(token, out var result);
            if (isInt)
                stack.Push(result);
            else
            {
                var second = stack.Pop();
                var first = stack.Pop();
                switch (token)
                {
                    case "+":
                        stack.Push(first + second);
                        break;
                    case "-":
                        stack.Push(first - second);
                        break;
                    case "*":
                        stack.Push(first * second);
                        break;
                    case "/":
                        stack.Push(first / second);
                        break;
                }
            }
        }
        return stack.Peek();
    }
}
