using UnityEngine;
using System.Collections;

public class BoardView : MonoBehaviour {

    public GameController GameController;

    private MarkView[,] Marks = new MarkView[Game.Columns, Game.Rows];

    public BoardView()
    {

    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Register(MarkView markView)
    {
        Marks[markView.Column, markView.Row] = markView;
    }

    public bool OnPutMarkRequested(int column, int row)
    {
        // TODO: Check is current player is managed by GUI

        return GameController.OnPutMarkRequested(column, row);
    }

    public Game GetGame()
    {
        return GameController.GetGame();
    }

}
