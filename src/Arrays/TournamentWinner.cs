namespace Algorithms.Arrays;
public static class TournamentWinner
{
    // O(n) time | O(k) space
    public static string First(List<List<string>> competitions, List<int> results)
    {
        var scores = new Dictionary<string, int>();
        var bestTeam = string.Empty;
        for (var i = 0; i < competitions.Count; i++)
            bestTeam = Convert.ToBoolean(results[i])
                ? EvaluateBestTeam(scores, bestTeam, competitions[i][0])
                : EvaluateBestTeam(scores, bestTeam, competitions[i][1]);

        return bestTeam;
    }

    private static string EvaluateBestTeam(Dictionary<string, int> scores, string bestTeam, string teamName)
    {
        if (scores.ContainsKey(teamName))
            scores[teamName] = scores[teamName] + 3;
        else
            scores.Add(teamName, 3);

        if (string.IsNullOrEmpty(bestTeam) || scores[teamName] > scores[bestTeam])
            bestTeam = teamName;
        return bestTeam;
    }
}
