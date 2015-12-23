using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IGameListener
{
    void OnPutMark(int column, int row, Mark mark);
    void OnGameOver(Line winnerLine);
    void OnNextPlayerTurn(Mark mark);
}
