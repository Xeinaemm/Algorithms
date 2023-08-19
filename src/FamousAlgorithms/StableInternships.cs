namespace Algorithms.FamousAlgorithms;
public static class StableInternships
{
    // O(n^2) time | O(n^2) space
    public static int[][] First(int[][] interns, int[][] teams)
    {
        var chosenInterns = new Dictionary<int, int>();
        var freeInterns = new Stack<int>();
        for (var i = 0; i < interns.Length; i++)
            freeInterns.Push(i);
        var currentInternChoices = new int[interns.Length];
        var teamDictionaries = new List<Dictionary<int, int>>();
        foreach (var team in teams)
        {
            var rank = new Dictionary<int, int>();
            for (var i = 0; i < team.Length; i++)
                rank[team[i]] = i;
            teamDictionaries.Add(rank);
        }

        while (freeInterns.Count != 0)
        {
            var internNum = freeInterns.Pop();
            var intern = interns[internNum];
            var teamPreference = intern[currentInternChoices[internNum]];
            currentInternChoices[internNum]++;

            if (!chosenInterns.ContainsKey(teamPreference))
            {
                chosenInterns[teamPreference] = internNum;
                continue;
            }

            var previousIntern = chosenInterns[teamPreference];
            var previousInternRank = teamDictionaries[teamPreference][previousIntern];
            var currentInternRank = teamDictionaries[teamPreference][internNum];
            if (currentInternRank < previousInternRank)
            {
                freeInterns.Push(previousIntern);
                chosenInterns[teamPreference] = internNum;
            }
            else
                freeInterns.Push(internNum);
        }
        var matches = new int[interns.Length][];
        var index = 0;
        foreach (var chosenIntern in chosenInterns)
        {
            matches[index] = new int[] { chosenIntern.Value, chosenIntern.Key };
            index++;
        }
        return matches;
    }
}