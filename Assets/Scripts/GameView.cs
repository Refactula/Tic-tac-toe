using UnityEngine;
using System.Collections.Generic;

public class GameView : MonoBehaviour, TicTacToeGame.IListener
{

    public GameObject WinnerLineObject;

    private GameController GameController;
    private WinnerLine WinnerLine;
    
    private CellScript[,] Cells = new CellScript[TicTacToeGame.Columns, TicTacToeGame.Rows];

    private List<GUIPlayer> Players = new List<GUIPlayer>();

    // Use this for initialization
    void Start()
    {
        GameController = GetComponent("GameController") as GameController;
        WinnerLine = WinnerLineObject.GetComponent("WinnerLine") as WinnerLine;
        GameController.RequestSubscribe(WinnerLine);
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

    public void OnGameOver(TicTacToeGame.Mark winnerMark, int variant)
    {
        Debug.Log("GameOver! Winner is " + winnerMark);
    }

    public void RegisterGUIPlayer(GUIPlayer player)
    {
        Players.Add(player);
    }

    public CellScript GetCell(int column, int row)
    {
        return Cells[column, row];
    }

}
