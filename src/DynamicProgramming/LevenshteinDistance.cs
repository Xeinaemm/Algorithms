namespace Algorithms.DynamicProgramming;
public static class LevenshteinDistance
{
    // O(nm) time | O(min(n, m)) space
    public static int First(string str1, string str2)
    {
        var smallStr = str1.Length < str2.Length ? str1 : str2;
        var bigStr = str1.Length >= str2.Length ? str1 : str2;
        var evenEdits = new int[smallStr.Length + 1];
        var oddEdits = new int[smallStr.Length + 1];
        for (var j = 0; j < smallStr.Length + 1; j++)
            evenEdits[j] = j;
        int[] currentEdits;
        int[] previousEdits;
        for (var i = 1; i < bigStr.Length + 1; i++)
        {
            if (i % 2 == 1)
            {
                currentEdits = oddEdits;
                previousEdits = evenEdits;
            }
            else
            {
                currentEdits = evenEdits;
                previousEdits = oddEdits;
            }
            currentEdits[0] = i;
            for (var j = 1; j < smallStr.Length + 1; j++)
                currentEdits[j] = bigStr[i - 1] == smallStr[j - 1]
                    ? previousEdits[j - 1]
                    : 1 + Math.Min(previousEdits[j - 1], Math.Min(previousEdits[j], currentEdits[j - 1]));
        }
        return bigStr.Length % 2 == 0 ?
            evenEdits[smallStr.Length] :
            oddEdits[smallStr.Length];
    }
}
