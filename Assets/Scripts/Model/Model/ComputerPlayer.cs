using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ComputerPlayer : IGameListener
{
    private readonly Mark Mark;

    public ComputerPlayer(Mark mark)
    {
        this.Mark = mark;
    }

    public void OnGameOver(Game game, Line winnerLine)
    {

    }

    public void OnPutMark(Game game, int column, int row, Mark mark)
    {
        
    }

    public void OnNextPlayerTurn(Game game, Mark mark)
    {
        if (this.Mark == mark)
        {
            Move(game);
        }
    }

    private void Move(Game game)
    {
        for (var c = 0; c < Game.Columns; c++)
        {
            for (var r = 0; r < Game.Rows; r++)
            {
                if (game.Get(c, r) == Mark.Unmarked)
                {
                    game.Put(c, r, Mark);
                    return;
                }
            }
        }
    }
}
