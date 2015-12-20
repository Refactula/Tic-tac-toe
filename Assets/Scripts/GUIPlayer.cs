using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class GUIPlayer : IPlayer 
{
    private GameController GameController;
    private TicTacToeGame.Mark Mark;

    public GUIPlayer(GameController gameController, TicTacToeGame.Mark mark)
    {
        GameController = gameController;
        Mark = mark;
    }

    public bool OnActAllowed()
    {
        return false;
    }

    public void OnPutFailed(int column, int row, string reason)
    {
        
    }

    public void OnPutSucceeded(int column, int row, TicTacToeGame.Mark mark)
    {

    }
    
    public void OnGameOver(TicTacToeGame.Mark winnerMark, int variant)
    {

    }


    public bool OnPutMarkRequested(int column, int row)
    {
        if (GameController.GetGame().GetCurrentTurn() == Mark)
        {
            GameController.RequestPutCell(column, row, Mark);
            return true;
        }
        return false;
    }
}
