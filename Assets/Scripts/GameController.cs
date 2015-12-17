using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	private TicTacToeGame game = new TicTacToeGame ();

	void Start () {
		
	}

	void Update () {
		
	}

	public void OnPutCellRequest(int column, int row) {
		Debug.Log ("Put cell requested: column = " + column + ", row = " + row);
		game.Put (column, row);
		game.LogState ();
	}

}
