namespace Algorithms.Arrays;
public static class ZigzagTraverse
{
    // O(n) time | O(n) space
    public static List<int> First(List<List<int>> array)
    {
        var height = array.Count - 1;
        var width = array[0].Count - 1;
        var result = new List<int>();
        var row = 0;
        var col = 0;
        var down = true;
        while (!IsOutOfBounds(row, col, height, width))
        {
            result.Add(array[row][col]);
            if (down)
                if (col == 0 || row == height)
                {
                    down = false;
                    if (row == height)
                        col++;
                    else
                        row++;
                }
                else
                {
                    row++;
                    col--;
                }
            else
                if (row == 0 || col == width)
            {
                down = true;
                if (col == width)
                    row++;
                else
                    col++;
            }
            else
            {
                row--;
                col++;
            }
        }
        return result;
    }

    private static bool IsOutOfBounds(int row, int col, int height, int width)
        => row < 0 || row > height || col < 0 || col > width;
}
