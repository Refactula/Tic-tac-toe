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

    public void Put(int column, int row, Mark mark)
    {
        if (IsGameOvered)
        {
            // Fail cause game is overed
            return;
        }

        if (column < 0 || column >= Columns || row < 0 || row >= Rows)
        {
            // Fail cause outside border
            return;
        }

        if (Board[column, row] != Mark.Nothing)
        {
            // Fail cause there is a mark on this position
            return;
        }

        Mark currentMark = GetCurrentMark();
        if (mark != currentMark)
        {
            // Fail cause not his turn
            return;
        }

        Board[column, row] = mark;
        MoveNumber++;
    }

    public Mark GetCurrentMark()
    {
        return MoveOrder[MoveNumber % MoveOrder.Length];
    }

}
