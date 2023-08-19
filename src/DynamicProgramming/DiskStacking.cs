namespace Algorithms.DynamicProgramming;
public static class DiskStacking
{
    public static List<int[]> First(List<int[]> disks)
    {
        disks.Sort((x, y) => x[2].CompareTo(y[2]));
        var heights = new int[disks.Count];
        for (var i = 0; i < disks.Count; i++)
            heights[i] = disks[i][2];
        var sequences = new int[disks.Count];
        for (var i = 0; i < disks.Count; i++)
            sequences[i] = int.MinValue;
        var maxHeightIdx = 0;
        for (var i = 1; i < disks.Count; i++)
        {
            var currentDisk = disks[i];
            for (var j = 0; j < i; j++)
            {
                var otherDisk = disks[j];
                if (ValidDimensions(otherDisk, currentDisk) && heights[i] <= currentDisk[2] + heights[j])
                {
                    heights[i] = currentDisk[2] + heights[j];
                    sequences[i] = j;
                }
            }
            if (heights[i] >= heights[maxHeightIdx])
                maxHeightIdx = i;
        }
        return BuildSequence(disks, sequences, maxHeightIdx);
    }

    private static bool ValidDimensions(int[] otherDisk, int[] currentDisk) =>
        otherDisk[0] < currentDisk[0] && otherDisk[1] < currentDisk[1] && otherDisk[2] < currentDisk[2];

    private static List<int[]> BuildSequence(List<int[]> array, int[] sequences, int currentIdx)
    {
        var sequence = new List<int[]>();
        while (currentIdx != int.MinValue)
        {
            sequence.Insert(0, array[currentIdx]);
            currentIdx = sequences[currentIdx];
        }
        return sequence;
    }
}
