using System.Collections;

public class Game {

    public const int Columns = 3;
    public const int Rows = 3;

    public readonly Mark[] MoveOrder = { Mark.Cross, Mark.Nought };

    private Mark[,] Board = new Mark[3, 3];

    private IPlayer[] Players;

    public Game(IPlayer crossPlayer, IPlayer noughtPlayer)
    {
        Players = new IPlayer[] { crossPlayer, noughtPlayer };
        for (var i = 0; i < Players.Length; i++)
        {
            Players[i].SetPlayingWith(MoveOrder[i]);
        }
    }

}
