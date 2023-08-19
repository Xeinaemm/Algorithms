namespace Algorithms.Stacks;
public static class SortStack
{
    // O(n^2) time | O(n) space
    public static List<int> First(List<int> stack)
    {
        if (stack.Count == 0)
            return stack;
        var value = stack[^1];
        stack.RemoveAt(stack.Count - 1);
        _ = First(stack);
        InsertInSortedOrder(stack, value);
        return stack;
    }

    public static void InsertInSortedOrder(List<int> stack, int value)
    {
        if (stack.Count == 0 || stack[^1] <= value)
        {
            stack.Add(value);
            return;
        }
        var top = stack[^1];
        stack.RemoveAt(stack.Count - 1);
        InsertInSortedOrder(stack, value);
        stack.Add(top);
    }
}
