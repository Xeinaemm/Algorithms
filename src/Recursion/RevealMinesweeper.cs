namespace Algorithms.Recursion;
public static class RevealMinesweeper
{
    // O(wh) time | O(wh)
    public static string[][] First(string[][] board, int row, int column)
    {
        if (board[row][column] == "M")
        {
            board[row][column] = "X";
            return board;
        }
        var neighbors = GetNeighbors(board, row, column);
        var numberOfMines = 0;
        foreach (var neighbor in neighbors)
            if (board[neighbor[0]][neighbor[1]] == "M")
                numberOfMines++;

        if (numberOfMines > 0)
            board[row][column] = numberOfMines.ToString();
        else
        {
            board[row][column] = "0";
            foreach (var neighbor in neighbors)
                if (board[neighbor[0]][neighbor[1]] == "H")
                    _ = First(board, neighbor[0], neighbor[1]);
        }

        return board;
    }

    private static List<List<int>> GetNeighbors(string[][] board, int row, int column)
    {
        var directions = new int[8, 2]
        {
          {0, 1},
          {0, -1},
          {1, 0},
          {-1, 0},
          {1, 1},
          {1, -1},
          {-1, 1},
          {-1, -1},
        };
        var neighbors = new List<List<int>>();
        for (var i = 0; i < directions.GetLength(0); i++)
        {
            var newRow = row + directions[i, 0];
            var newColumn = column + directions[i, 1];
            if (newRow >= 0 && newColumn >= 0 && newRow < board.Length && newColumn < board[row].Length)
                neighbors.Add(new List<int> { newRow, newColumn });
        }
        return neighbors;
    }
}
