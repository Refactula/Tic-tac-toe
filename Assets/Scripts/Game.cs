using System.Collections;

public class Game {

    public const int Columns = 3;
    public const int Rows = 3;

    public readonly Mark[] MoveOrder = { Mark.Cross, Mark.Nought };

    private Mark[,] Board = new Mark[3, 3];

    private AbstractPlayer[] Players;

    private int MoveNumber = 0;

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

}
