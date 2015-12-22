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

    public void OnPutMarkRequested(int column, int row)
    {
        // TODO: Check is current player is managed by GUI

        GameController.OnPutMarkRequested(column, row);
    }

    public void OnPutMark(int column, int row, Mark mark)
    {
        Marks[column, row].Become(mark);
    }

    public Game GetGame()
    {
        return GameController.GetGame();
    }

}
