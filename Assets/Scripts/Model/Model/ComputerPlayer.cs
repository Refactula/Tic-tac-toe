using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ComputerPlayer : IGameListener
{
    private readonly IGameController GameController;
    private readonly Mark Mark;

    public ComputerPlayer(IGameController gameController, Mark mark)
    {
        this.GameController = gameController;
        this.Mark = mark;
    }

    public void OnGameOver(IGame game, Line winnerLine)
    {

    }

    public void OnPutMark(IGame game, int column, int row, Mark mark)
    {
        
    }

    public void OnNextPlayerTurn(IGame game, Mark mark)
    {
        if (this.Mark == mark)
        {
            Move(game);
        }
    }

    private void Move(IGame game)
    {
        for (var c = 0; c < Game.Columns; c++)
        {
            for (var r = 0; r < Game.Rows; r++)
            {
                if (game.Get(c, r) == Mark.Unmarked)
                {
                    GameController.RequestPut(c, r, Mark);
                    return;
                }
            }
        }
    }
}
