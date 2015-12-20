using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AIPlayer : IPlayer 
{

    private GameController GameController;

    private TicTacToeGame.Mark Mark;

    public AIPlayer(GameController gameController, TicTacToeGame.Mark mark)
    {
        GameController = gameController;
        Mark = mark;
    }

    

    public void OnPutFailed(int column, int row, string reason)
    {
        
    }

    public void OnPutSucceeded(int column, int row, TicTacToeGame.Mark mark)
    {

    }
    
    public void OnGameOver(TicTacToeGame.Mark winnerMark)
    {

    }

    public bool OnActAllowed()
    {
        TicTacToeGame game = GameController.GetGame();
        if (!game.IsGameOver() && game.GetCurrentTurn() == Mark)
            for (int c = 0; c < TicTacToeGame.Columns; c++)
                for (int r = 0; r < TicTacToeGame.Rows; r++)
                    if (game.Get(c, r) == TicTacToeGame.Mark.Unmarked)
                    {
                        GameController.OnPutCellRequest(c, r, Mark);
                        return true;
                    }
        return false;
    }
}
