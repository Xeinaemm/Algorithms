namespace Algorithms.Arrays;
public static class MajorityElement
{
    // O(n) time | O(1) space
    public static int First(int[] array)
    {
        int answer = 0, count = 0;
        for (var i = 0; i < array.Length; i++)
            if (count == 0)
            {
                answer = array[i];
                count++;
            }
            else if (array[i] == answer)
                count++;
            else
                count--;
        return answer;
    }
}
