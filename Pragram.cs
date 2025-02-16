public class Pragram {
    public int[][] CandyCrush(int[][] board) {
        int rows = board.Length;
        int cols = board[0].Length;

        while(true)
        {
            HashSet<(int, int)> candies = FindCandyToCrush(board, rows, cols);
            if(candies.Count == 0)
            {
                break;
            }
            CrushCandy(board, candies);
            ShiftCandiesToEmptySpaces(board, rows, cols);
        }

        return board;
    }

    private HashSet<(int, int)> FindCandyToCrush(int[][] board, int rows, int cols)
    {
        HashSet<(int, int)> hashSet = new();

        // Check Vertically Adjacent Candies
        for(int row = 1; row < rows - 1; row++)
        {
            for(int col = 0; col < cols; col++)
            {
                if(board[row][col] == 0)
                {
                    continue;
                }

                if(board[row - 1][col] == board[row][col] && board[row][col] == board[row + 1][col])
                {
                    hashSet.Add((row - 1, col));
                    hashSet.Add((row, col));
                    hashSet.Add((row + 1, col));
                }
            }
        }

        // Check Horizontally Adjacent Candies
        for(int row = 0; row < rows; row++)
        {
            for(int col = 1; col < cols - 1; col++)
            {
                if(board[row][col] == 0)
                {
                    continue;
                }

                if(board[row][col - 1] == board[row][col] && board[row][col] == board[row][col + 1])
                {
                    hashSet.Add((row, col - 1));
                    hashSet.Add((row, col));
                    hashSet.Add((row, col + 1));
                }
            }
        }

        return hashSet;
    }

    private void CrushCandy(int[][] board, HashSet<(int, int)> hashSet)
    {
        foreach((int row, int col) in hashSet)
        {
            board[row][col] = 0;
        }
    }

    private void ShiftCandiesToEmptySpaces(int[][] board, int rows, int cols)
    {
        for (int col = 0; col < cols; col++) 
        {
            int lowestZero = -1;
            for (int row = rows - 1; row >= 0; row--) 
            {
                if (board[row][col] == 0) 
                {
                    lowestZero = Math.Max(lowestZero, row);
                } 
                else if (lowestZero >= 0) 
                {
                    (board[lowestZero][col], board[row][col]) = (board[row][col], board[lowestZero][col]);
                    lowestZero--;
                }
            }
        }
    }
}
