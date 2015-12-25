using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Game : IGame
{
    public const int Columns = 3;
    public const int Rows = 3;

    private static readonly Mark[] MoveSequence = { Mark.Cross, Mark.Nought };

    private Mark[,] Board = new Mark[Columns, Rows];

    private int MoveNumber = 0;

    private bool GameOver = false;

    private Line WinningLine = null;

    private List<IGameListener> Listeners = new List<IGameListener>();

    public Mark Get(int column, int row)
    {
        return Board[column, row];
    }

    public void Put(int column, int row, Mark mark)
    {
        if (GameOver)
        {
            return;
        }

        if (mark != GetCurrentMark())
        {
            return;
        }

        if (column < 0 || column >= Columns || row < 0 || row >= Rows)
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
            Listeners.ForEach(listener => listener.OnGameOver(this, WinningLine));
        } 
        else
        {
            Listeners.ForEach(listener => listener.OnNextPlayerTurn(this, GetCurrentMark()));
        }
    }

    private Mark GetCurrentMark()
    {
        return MoveSequence[MoveNumber % 2];
    }

    private void DetectGameOver()
    {
        // Detect win
        foreach (var line in Line.AllPossibleLines)
        {
            Mark mark = Get(line.GetColumn(0), line.GetRow(0));
            if (mark != Mark.Unmarked)
            {
                bool allSame = true;
                for (var i = 1; allSame && i < Line.Size; i++)
                {
                    if (Get(line.GetColumn(i), line.GetRow(i)) != mark)
                    {
                        allSame = false;
                    }
                }
                if (allSame)
                {
                    GameOver = true;
                    WinningLine = line;
                    return;
                }
            }
        }

        // Detect draw
        for (var column = 0; column < Columns; column++)
        {
            for (var row = 0; row < Rows; row++)
            {
                if (Get(column, row) == Mark.Unmarked)
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
}
