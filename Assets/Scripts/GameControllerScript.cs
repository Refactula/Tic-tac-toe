using UnityEngine;
using System.Collections;

public class GameControllerScript : MonoBehaviour {

	public GameObject GameViewObject;

	private GameViewScript GameView;

	private TicTacToeGame Game;

	void Start () {
		GameView = GameViewObject.GetComponent ("GameViewScript") as GameViewScript;
		Game = new TicTacToeGame ();
		Game.SetListener (GameView);
	}

	void Update () {
		
	}

	public void OnPutCellRequest(int column, int row) {
		Debug.Log ("Put cell requested (" + column + ", " + row + ")");
		Game.Put (column, row);
		Game.LogState ();
	}

}
