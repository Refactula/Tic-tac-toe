using System.Collections.Generic;

public class Game
{

    public const int Columns = 3;
    public const int Rows = 3;

    public const int LineLength = 3;

    public static readonly Mark[] MoveOrder = { Mark.Cross, Mark.Nought };

    private static readonly IList<Line> AllPossibleLines = new List<Line>();

    static Game()
    {
        for (int c = 0; c < Columns; c++)
        {
            for (int r = 0; r < Rows; r++)
            {
                AddLineIfExists(c, r, c + LineLength - 1, r);
                AddLineIfExists(c, r, c, r + LineLength - 1);
                AddLineIfExists(c, r, c + LineLength - 1, r + LineLength - 1);
                AddLineIfExists(c, r, c - LineLength + 1, r + LineLength - 1);
            }
        }
    }

    private static void AddLineIfExists(int fromColumn, int fromRow, int toColumn, int toRow)
    {
        if (IsOnBoard(fromColumn, fromRow) && IsOnBoard(toColumn, toRow))
        {
            AllPossibleLines.Add(new Line(fromColumn, fromRow, toColumn, toRow));
        }
    }

    public static bool IsOnBoard(int column, int row)
    {
        return column >= 0 && column < Columns && row >= 0 && row < Rows;
    }

    private Mark[,] Board = new Mark[3, 3];

    private AbstractPlayer[] Players;

    private int MoveNumber = 0;

    private Mark Winner = Mark.Unmarked;

    private Line WinnerLine;

    private bool IsGameOvered = false;

    public Game(AbstractPlayer crossPlayer, AbstractPlayer noughtPlayer)
    {
        Players = new AbstractPlayer[] { crossPlayer, noughtPlayer };
        for (var i = 0; i < Players.Length; i++)
        {
            Players[i].SetPlayingWith(MoveOrder[i]);
        }
    }

    public bool Put(int column, int row, Mark mark)
    {
        if (IsGameOvered)
        {
            // Fail cause game is overed
            return false;
        }

        if (column < 0 || column >= Columns || row < 0 || row >= Rows)
        {
            // Fail cause outside border
            return false;
        }

        if (Board[column, row] != Mark.Unmarked)
        {
            // Fail cause there is a mark on this position
            return false;
        }

        Mark currentMark = GetCurrentMark();
        if (mark != currentMark)
        {
            // Fail cause not his turn
            return false;
        }

        Board[column, row] = mark;
        MoveNumber++;
        return true;
    }

    public Mark GetMark(int column, int row)
    {
        return Board[column, row];
    }

    public Mark GetCurrentMark()
    {
        return MoveOrder[MoveNumber % MoveOrder.Length];
    }

    public void DetectGameOver()
    {
        if (!IsGameOvered)
        {
            FindWinner();
        }
        if (!IsGameOvered) {
            DetectDraw();
        }
    }

    private void FindWinner()
    {
        foreach (var line in AllPossibleLines)
        {
            Mark possibleWinner = Mark.Unmarked;
            bool isGameOver = true;
            for (var i = 0; isGameOver && i < line.Size; i++)
            {
                int c = line.FromColumn + line.ColumnStep * i;
                int r = line.FromRow + line.RowStep * i;
                Mark mark = Board[c, r];
                if (mark != Mark.Unmarked && (possibleWinner == Mark.Unmarked || possibleWinner == mark))
                {
                    possibleWinner = mark;
                }
                else
                {
                    isGameOver = false;
                }
            }
            if (isGameOver)
            {
                this.Winner = possibleWinner;
                this.WinnerLine = line;
                this.IsGameOvered = true;
                return;
            }
        }
    }

    private void DetectDraw()
    {
        bool isGameOver = true;
        for (var c = 0; isGameOver && c < Columns; c++)
        {
            for (var r = 0; isGameOver && r < Rows; r++)
            {
                if (Board[c, r] == Mark.Unmarked)
                {
                    isGameOver = false;
                }
            }
        }
        if (isGameOver)
        {
            this.Winner = Mark.Unmarked;
            this.IsGameOvered = true;
            return;
        }
    }
}
