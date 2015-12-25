using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameListener
{
    void OnPutMark(IGame game, int column, int row, Mark mark);
    void OnGameOver(IGame game, Line winnerLine);
    void OnNextPlayerTurn(IGame game, Mark mark);
}
