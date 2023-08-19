namespace Algorithms.Stacks;
public class MinMaxStack
{
    private readonly List<List<int>> minMax = new();
    private readonly List<int> stack = new();

    // O(1) time | O(1) space
    public int Peek() =>
      stack[^1];

    // O(1) time | O(1) space
    public int Pop()
    {
        minMax.RemoveAt(minMax.Count - 1);
        var result = stack[^1];
        stack.RemoveAt(stack.Count - 1);
        return result;
    }

    // O(1) time | O(1) space
    public void Push(int number)
    {
        if (minMax.Count == 0)
            minMax.Add(new List<int> { number, number });
        else
        {
            var lastMinMax = minMax[^1];
            minMax.Add(new List<int> { Math.Min(number, lastMinMax[0]), Math.Max(number, lastMinMax[1]) });
        }
        stack.Add(number);
    }

    // O(1) time | O(1) space
    public int GetMin() =>
      minMax[^1][0];

    // O(1) time | O(1) space
    public int GetMax() =>
      minMax[^1][1];
}
