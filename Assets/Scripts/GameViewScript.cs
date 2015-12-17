using UnityEngine;
using System.Collections;

public class GameViewScript : MonoBehaviour, TicTacToeGame.IListener {

	public GameObject GameControllerObject;

	private GameControllerScript GameController;

	private CellScript[, ] Cells = new CellScript[TicTacToeGame.Columns, TicTacToeGame.Rows];

	// Use this for initialization
	void Start () {
		GameController = GameControllerObject.GetComponent ("GameControllerScript") as GameControllerScript;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPutCellRequested(int column, int row) {
		GameController.OnPutCellRequest (column, row);
	}

	public void RegisterCell (CellScript cell) {
		Cells [cell.Column, cell.Row] = cell;
	}

	public void OnPutSucceeded(int column, int row, TicTacToeGame.Mark mark) {
		Cells [column, row].Become (mark);
	}

	public void OnPutFailed(int column, int row, string reason) {
		Debug.LogWarning("Failed to mark a cell (" + column + ", " + row + "): " + reason);
	}

}
