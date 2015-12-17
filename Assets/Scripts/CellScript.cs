using UnityEngine;
using System.Collections;

public class CellScript : MonoBehaviour {

	public int Column;
	public int Row;

	public GameObject GameViewObject;
	public Sprite CrossSprite;
	public Sprite NoughtSprite;

	private GameViewScript GameView;

	// Use this for initialization
	void Start () {
		GameView = GameViewObject.GetComponent ("GameViewScript") as GameViewScript;	
		GameView.RegisterCell (this);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseDown() {
		GameView.OnPutCellRequested (Column, Row);
	}

	public void Become(TicTacToeGame.Mark mark) {
		SpriteRenderer renderer = GetComponent ("SpriteRenderer") as SpriteRenderer;
		switch (mark) {
		case TicTacToeGame.Mark.Cross:
			renderer.sprite = CrossSprite;
			break;
		case TicTacToeGame.Mark.Nought:
			renderer.sprite = NoughtSprite;
			break;
		default:
			renderer.sprite = null;
			break;
		}
	}

}
