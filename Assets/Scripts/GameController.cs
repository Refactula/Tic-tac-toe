using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{

    private GameView GameView;

    private TicTacToeGame Game;
    private IPlayer[] Players;

    void Start()
    {
        GameView = GetComponent("GameView") as GameView;
        Game = new TicTacToeGame();
        Game.AddListener(GameView);
        Players = new IPlayer[] {
            CreateGUIPlayer(TicTacToeGame.Mark.Cross),
            CreateGUIPlayer(TicTacToeGame.Mark.Nought)
        };
    }

    private GUIPlayer CreateGUIPlayer(TicTacToeGame.Mark mark)
    {
        GUIPlayer player = new GUIPlayer(this, mark);
        GameView.RegisterGUIPlayer(player);
        return player;
    }

    void Update()
    {

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

    public int GetPlayersCount()
    {
        return Players.Length;
    }

    public IPlayer GetPlayer(int i)
    {
        return Players[i];
    }

}
