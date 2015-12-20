using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{

    private GameView GameView;

    private TicTacToeGame Game;
    private List<IPlayer> Players = new List<IPlayer>();

    void Start()
    {
        GameView = GetComponent("GameView") as GameView;
        Game = new TicTacToeGame();
        Game.AddListener(GameView);
        CreateGUIPlayer(TicTacToeGame.Mark.Cross);
        CreateAIPlayer(TicTacToeGame.Mark.Nought);
    }

    private void CreateGUIPlayer(TicTacToeGame.Mark mark)
    {
        GUIPlayer player = new GUIPlayer(this, mark);
        Players.Add(player);
        Game.AddListener(player);
        GameView.RegisterGUIPlayer(player);
    }

    private void CreateAIPlayer(TicTacToeGame.Mark mark)
    {
        AIPlayer player = new AIPlayer(this, mark);
        Players.Add(player);
        Game.AddListener(player);
    }

    void Update()
    {
        foreach (IPlayer player in Players)
            if (player.OnActAllowed())
                break;
    }

    public void OnPutCellRequest(int column, int row, TicTacToeGame.Mark mark)
    {
        Debug.Log("Put cell requested (" + column + ", " + row + ")");
        Game.Put(column, row, mark);
        Game.LogState();
    }

    public TicTacToeGame GetGame()
    {
        return Game;
    }

}
