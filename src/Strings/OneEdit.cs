namespace Algorithms.Strings;
public static class OneEdit
{
    // O(n) time | O(1) space
    public static bool First(string stringOne, string stringTwo)
    {
        if (Math.Abs(stringOne.Length - stringTwo.Length) > 1)
            return false;

        return stringOne.Length > stringTwo.Length ?
            CheckOneEdit(stringTwo, stringOne) :
            CheckOneEdit(stringOne, stringTwo);
    }

    public static bool CheckOneEdit(string smallerStr, string longerStr)
    {
        var madeEdit = false;
        for (int s = 0, l = 0; s < smallerStr.Length && l < longerStr.Length; s++, l++)
            if (smallerStr[s] != longerStr[l])
            {
                if (madeEdit)
                    return false;
                madeEdit = true;
                if (smallerStr.Length != longerStr.Length)
                    s--;
            }

        return true;
    }
}
