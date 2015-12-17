using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TicTacToeGame
{
    public const int Columns = 3;
    public const int Rows = 3;

    public enum Mark { Unmarked, Cross, Nought }
    
    public interface IListener
    {
        void OnPutSucceeded();
        void OnPutFailed(String reason);
    }

    public static readonly Mark[] MoveOrder = { Mark.Cross, Mark.Nought };
    
    private Mark[,] Board = new Mark[Columns, Rows];
    private int CurrentMove = 0;
    private IListener Listener; 

    public Mark Get(int column, int row)
    {
        return Board[column, row];
    }

    public void Put(int column, int row)
    {
        if (column < 0 || column >= Columns || row < 0 || row >= Rows)
        {
            if (Listener != null)
                Listener.OnPutFailed("Outside the board");
            return;
        }

        if (Board[column, row] != Mark.Unmarked)
        {
            if (Listener != null)
                Listener.OnPutFailed("This cell is already occupied");
            return;
        }

        Mark currentMark = MoveOrder[CurrentMove % MoveOrder.Length];
        Board[column, row] = currentMark;
        CurrentMove++;

        // TODO find out if game has ended

        if (Listener != null)
            Listener.OnPutSucceeded();
    }

    public void SetListener(IListener listener)
    {
        this.Listener = listener;
    }

	public void LogState () 
	{
		Debug.Log (GetMarkChar (Board [0, 0]) + "|" + GetMarkChar(Board[1, 0]) + "|" + GetMarkChar(Board[2, 0]) + "\n" + 
			"-----\n" + 
			GetMarkChar (Board [0, 1]) + "|" + GetMarkChar(Board[1, 1]) + "|" + GetMarkChar(Board[2, 1]) + "\n" + 
			"-----\n" + 
			GetMarkChar (Board [0, 2]) + "|" + GetMarkChar(Board[1, 2]) + "|" + GetMarkChar(Board[2, 2]));
	}

	private char GetMarkChar(Mark mark)
	{
		switch (mark) {
		case Mark.Cross:
			return 'X';
		case Mark.Nought:
			return 'O';
		default:
			return ' ';
		}
	}
}
