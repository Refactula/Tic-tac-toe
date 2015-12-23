using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameListener
{
    void OnPutMark(Game game, int column, int row, Mark mark);
    void OnGameOver(Game game, Line winnerLine);
    void OnNextPlayerTurn(Game game, Mark mark);
}
