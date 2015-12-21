using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameBoardView GameView;

    private Game Game;

    public GameController()
    {
        Game = new Game(new HumanPlayer(), new HumanPlayer());
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
