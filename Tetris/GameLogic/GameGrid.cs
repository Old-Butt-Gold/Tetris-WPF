namespace Tetris;

public class GameGrid
{
    readonly int[,] _grid;
    public int Rows { get; private set; }
    public int Columns { get; private set; }

    public int this[int r, int c]
    {
        get => _grid[r, c];
        set => _grid[r, c] = value;
    }

    public GameGrid(int rows, int columns)
    {
        Rows = rows;
        Columns = columns;
        _grid = new int[rows, columns];
    }

    public bool IsInside(int r, int c) => r > -1 && r < Rows && c > -1 && c < Columns;

    public bool IsEmpty(int r, int c) => IsInside(r, c) && _grid[r, c] is 0;

    public bool IsRowFull(int r)
    {
        for (int c = 0; c < Columns; c++)
            if (_grid[r, c] == 0)
                return false;

        return true;
    }

    public bool IsRowEmpty(int r)
    {
        for (int c = 0; c < Columns; c++)
            if (_grid[r, c] != 0)
                return false;
        return true;
    }

    void ClearRow(int r)
    {
        for (int c = 0; c < Columns; c++)
            _grid[r, c] = 0;
    }

    void MoveRowDown(int r, int numRows)
    {
        for (int c = 0; c < Columns; c++)
        {
            _grid[r + numRows, c] = _grid[r, c];
            _grid[r, c] = 0;
        }
    }

    public int ClearFullRows()
    {
        int cleared = 0;
        for (int r = Rows - 1; r > -1; r--)
        {
            if (IsRowFull(r))
            {
                ClearRow(r);
                cleared++;
            }
            else if (cleared > 0)
            {
                MoveRowDown(r, cleared);
            }
        }

        return cleared;
    }
    
    
}