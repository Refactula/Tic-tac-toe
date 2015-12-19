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
		void OnPutSucceeded(int column, int row, Mark mark);
		void OnPutFailed(int column, int row, String reason);
    }

    public static readonly Mark[] Turns = { Mark.Cross, Mark.Nought };
    
    private Mark[,] Board = new Mark[Columns, Rows];
    private int CurrentMove = 0;
    private List<IListener> Listeners = new List<IListener>(); 

    public Mark Get(int column, int row)
    {
        return Board[column, row];
    }

    public void Put(int column, int row, Mark mark)
    {
        if (column < 0 || column >= Columns || row < 0 || row >= Rows)
        {
            Listeners.ForEach(listener => listener.OnPutFailed(column, row, "Outside the board"));
            return;
        }

        if (Board[column, row] != Mark.Unmarked)
        {
            Listeners.ForEach(listener => listener.OnPutFailed(column, row, "This cell is already occupied"));
            return;
        }

        if (mark != GetCurrentTurn())
        {
            Listeners.ForEach(listener => listener.OnPutFailed(column, row, "Trying to put wrong mark"));
            return;
        }

        Board[column, row] = mark;

        // TODO find out if game has ended

        Listeners.ForEach(listener => listener.OnPutSucceeded(column, row, mark));

        CurrentMove++;
    }

    public Mark GetCurrentTurn()
    {
        return Turns[CurrentMove % Turns.Length];
    }

    public void AddListener(IListener listener)
    {
        Listeners.Add(listener);
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
