namespace Algorithms.GreedyAlgorithms;
public static class TaskAssignment
{
    // O(nlog(n)) time | O(n) space
    public static List<List<int>> First(int k, List<int> tasks)
    {
        var result = new List<List<int>>();
        var tasksMap = tasks
            .Select((value, index) => new { index, value })
            .OrderBy(x => x.value)
            .Select(x => x.index)
            .ToList();

        for (var i = 0; i < k; i++)
            result.Add(new List<int> { tasksMap[i], tasksMap[tasksMap.Count - i - 1] });

        return result;
    }
}
