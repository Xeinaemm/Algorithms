namespace Algorithms.Arrays;
public static class MinRewards
{
    // O(n) time | O(n) space
    public static int First(int[] scores)
    {
        var rewards = new int[scores.Length];
        Array.Fill(rewards, 1);
        for (var i = 1; i < scores.Length; i++)
            if (scores[i - 1] < scores[i])
                rewards[i] = rewards[i - 1] + 1;
        for (var i = scores.Length - 2; i >= 0; i--)
            if (scores[i] > scores[i + 1])
                rewards[i] = Math.Max(rewards[i + 1] + 1, rewards[i]);
        return rewards.Sum();
    }
}
