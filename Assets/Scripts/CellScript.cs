using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {

	public int column;
	public int row;

	public GameObject gameControllerObject;

	private GameController gameController;

	// Use this for initialization
	void Start () {
		gameController = gameControllerObject.GetComponent ("GameController") as GameController;	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		gameController.OnPutCellRequest (column, row);
	}
}
