using UnityEngine;
using System.Collections;
using System;

public class GameController : MonoBehaviour, IGameController {

    private Game game = new Game();

    public IGame Game
    {
        get
        {
            return game;
        }
    }

    public void RequestPut(int column, int row, Mark mark)
    {
        game.Put(column, row, mark);
    }


}
