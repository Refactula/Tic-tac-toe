using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game : IGame
{
    private const int _ColumnsAmount = 3;
    private const int _RowsAmount = 3;

    private static readonly Mark[] MoveSequence = { Mark.Cross, Mark.Nought };

    private Mark[,] Board = new Mark[_ColumnsAmount, _RowsAmount];

    private int MoveNumber = 0;

    private bool GameOver = false;

    private Line WinningLine = null;

    private Mark WinnerMark = Mark.Unmarked;

    private List<IGameListener> Listeners = new List<IGameListener>();

    public int ColumnsAmount {
        get
        {
            return _ColumnsAmount;
        }
    }

    public int RowsAmount
    {
        get
        {
            return _RowsAmount;
        }
    }

    public void Start()
    {
        if (MoveNumber > 0)
        {
            return;
        }
        Listeners.ForEach(listener => listener.OnNextPlayerTurn(this, GetCurrentTurn()));
    }

    public Mark GetMark(int column, int row)
    {
        return Board[column, row];
    }

    public void Put(int column, int row, Mark mark)
    {
        if (GameOver)
        {
            return;
        }

        if (mark != GetCurrentTurn())
        {
            return;
        }

        if (column < 0 || column >= ColumnsAmount || row < 0 || row >= _RowsAmount)
        {
            return;
        }

        if (Board[column, row] != Mark.Unmarked)
        {
            return;
        }

        Board[column, row] = mark;
        Listeners.ForEach(listener => listener.OnPutMark(this, column, row, mark));

        MoveNumber++;
        DetectGameOver();

        if (GameOver)
        {
            Listeners.ForEach(listener => listener.OnGameOver(this, WinningLine, WinnerMark));
        } 
        else
        {
            Listeners.ForEach(listener => listener.OnNextPlayerTurn(this, GetCurrentTurn()));
        }
    }

    public Mark GetCurrentTurn()
    {
        return MoveSequence[MoveNumber % 2];
    }

    private void DetectGameOver()
    {
        // Detect win
        foreach (var line in Line.AllPossibleLines)
        {
            Mark winnerMark = GetMark(line.GetColumn(0), line.GetRow(0));
            if (winnerMark != Mark.Unmarked)
            {
                bool allSame = true;
                for (var i = 1; allSame && i < Line.Size; i++)
                {
                    if (GetMark(line.GetColumn(i), line.GetRow(i)) != winnerMark)
                    {
                        allSame = false;
                    }
                }
                if (allSame)
                {
                    GameOver = true;
                    WinningLine = line;
                    WinnerMark = winnerMark;
                    return;
                }
            }
        }

        // Detect draw
        for (var column = 0; column < ColumnsAmount; column++)
        {
            for (var row = 0; row < RowsAmount; row++)
            {
                if (GetMark(column, row) == Mark.Unmarked)
                {
                    return;
                }
            }
        }

        GameOver = true;
    }

    public void Subscribe(IGameListener listener)
    {
        Listeners.Add(listener);
    }

    public bool IsOverred()
    {
        return GameOver;
    }

    public bool HasWinner()
    {
        return WinnerMark != Mark.Unmarked;
    }

    public Line GetWinningLine()
    {
        return WinningLine;
    }

    public Mark GetWinnerMark()
    {
        return WinnerMark;
    }
}
