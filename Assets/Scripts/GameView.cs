using UnityEngine;
using System.Collections.Generic;

public class GameView : MonoBehaviour, TicTacToeGame.IListener
{

    private GameController GameController;

    private CellScript[,] Cells = new CellScript[TicTacToeGame.Columns, TicTacToeGame.Rows];

    private List<GUIPlayer> Players = new List<GUIPlayer>();

    // Use this for initialization
    void Start()
    {
        GameController = GetComponent("GameController") as GameController;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPutMarkRequested(int column, int row)
    {
        foreach (GUIPlayer player in Players)
        {
            if (player.OnPutMarkRequested(column, row))
            {
                break;
            }
        }
    }

    public void RegisterCell(CellScript cell)
    {
        Cells[cell.Column, cell.Row] = cell;
    }

    public void OnPutSucceeded(int column, int row, TicTacToeGame.Mark mark)
    {
        Cells[column, row].Become(mark);
    }

    public void OnPutFailed(int column, int row, string reason)
    {
        Debug.LogWarning("Failed to mark a cell (" + column + ", " + row + "): " + reason);
    }

    public void RegisterGUIPlayer(GUIPlayer player)
    {
        Players.Add(player);
    }

}
