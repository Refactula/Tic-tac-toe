using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public BoardView BoardView;

    private Game Game;

    public GameController()
    {
        Game = new Game(new HumanPlayer(), new HumanPlayer());
    }
    
	void Start () {

	}
	
	void Update () {
	
	}

    public Game GetGame()
    {
        return Game;
    }

    public void OnPutMarkRequested(int column, int row)
    {
        if (Game.Put(column, row, Game.GetCurrentMark()))
        {
            BoardView.OnPutMark(column, row, Game.GetMark(column, row));
            Game.DetectGameOver();
        }
    }

}
