namespace Algorithms.Arrays;
public static class KnightConnection
{
    // O(nm) time | O(nm) space
    public static int First(int[] knightA, int[] knightB)
    {
        var moves = new int[8, 2]
        {
            { -2, 1 },
            { -1, 2 },
            { 1, 2 },
            { 2, 1 },
            { 2, -1 },
            { 1, -2 },
            { -1, -2 },
            { -2, -1 },
        };
        var queue = new Queue<List<int>>();
        queue.Enqueue(new List<int> { knightA[0], knightA[1], 0 });
        var visited = new HashSet<string>();
        while (queue.Count > 0)
        {
            var currentPosition = queue.Dequeue();
            if (currentPosition[0] == knightB[0] && currentPosition[1] == knightB[1])
                return (int)Math.Ceiling((double)currentPosition[2] / 2);
            for (var i = 0; i < moves.GetLength(0); i++)
            {
                var position = new List<int>
                {
                    currentPosition[0] + moves[i, 0],
                    currentPosition[1] + moves[i, 1]
                };
                var positionString = string.Join(", ", position);
                if (!visited.Contains(positionString))
                {
                    position.Add(currentPosition[2] + 1);
                    queue.Enqueue(position);
                    _ = visited.Add(positionString);
                }
            }
        }
        return -1;
    }
}
