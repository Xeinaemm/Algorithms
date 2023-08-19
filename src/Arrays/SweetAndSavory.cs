namespace Algorithms.Arrays;
public static class SweetAndSavory
{
    // O(nlog(n)) time | O(n) space
    public static int[] First(int[] dishes, int target)
    {
        var resultArr = new int[2];
        var bestDiff = int.MaxValue;
        int sweetPtr = 0, savoryPtr = 0;
        var sweetArr = dishes.Where(x => x < 0).ToList();
        sweetArr.Sort((a, b) => Math.Abs(a) - Math.Abs(b));
        var savoryArr = dishes.Where(x => x > 0).ToList();
        savoryArr.Sort();
        while (sweetPtr < sweetArr.Count && savoryPtr < savoryArr.Count)
        {
            var dishesPair = sweetArr[sweetPtr] + savoryArr[savoryPtr];
            if (dishesPair <= target)
            {
                var currentDiff = target - dishesPair;
                if (currentDiff < bestDiff)
                {
                    bestDiff = currentDiff;
                    resultArr[0] = sweetArr[sweetPtr];
                    resultArr[1] = savoryArr[savoryPtr];
                }
                savoryPtr++;
            }
            else
                sweetPtr++;

        }
        return resultArr;
    }
}
