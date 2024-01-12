namespace Algorithms.DynamicProgramming;
public static class KnapsackProblem
{
    // O(nc) time | O(nc) space
    public static List<List<int>> First(int[,] items, int capacity)
    {
        var values = new int[items.GetLength(0) + 1, capacity + 1];
        for (var i = 1; i < items.GetLength(0) + 1; i++)
        {
            var currentWeight = items[i - 1, 1];
            var currentValue = items[i - 1, 0];
            for (var c = 0; c < capacity + 1; c++)
                values[i, c] = currentWeight > c
                    ? values[i - 1, c]
                    : values[i, c] = Math.Max(values[i - 1, c], values[i - 1, c - currentWeight] + currentValue);
        }

        return GetKnapsackItems(values, items, values[items.GetLength(0), capacity]);
    }

    private static List<List<int>> GetKnapsackItems(int[,] values, int[,] items, int weight)
    {
        var sequence = new List<List<int>>()
        {
            new()
            {
                weight
            },
            new()
        };
        var i = values.GetLength(0) - 1;
        var c = values.GetLength(1) - 1;
        while (i > 0)
        {
            if (values[i, c] == values[i - 1, c])
                i--;
            else
            {
                sequence[1].Insert(0, i - 1);
                c -= items[i - 1, 1];
                i--;
            }
            if (c == 0)
                break;
        }
        return sequence;
    }
}
