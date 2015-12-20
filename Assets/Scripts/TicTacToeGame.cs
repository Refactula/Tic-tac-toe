using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class TicTacToeGame
{
    public const int Columns = 3;
    public const int Rows = 3;

    public static int[,,] GameOverVariants =
    {
        // Horizontal
        { {0, 0}, {0, 1}, {0, 2} },
        { {1, 0}, {1, 1}, {1, 2} },
        { {2, 0}, {2, 1}, {2, 2} },

        // Vertical
        { {0, 0}, {1, 0}, {2, 0} },
        { {0, 1}, {1, 1}, {2, 1} },
        { {0, 2}, {1, 2}, {2, 2} },

        // Diagonal
        { {0, 0}, {1, 1}, {2, 2} },
        { {0, 2}, {1, 1}, {2, 0} },

    };

    public enum Mark { Unmarked, Cross, Nought }
    
    public interface IListener
    {
		void OnPutSucceeded(int column, int row, Mark mark);
		void OnPutFailed(int column, int row, String reason);
        void OnGameOver(Mark winnerMark);
    }

    public static readonly Mark[] Turns = { Mark.Cross, Mark.Nought };
    
    private Mark[,] Board = new Mark[Columns, Rows];
    private int CurrentMove = 0;
    private List<IListener> Listeners = new List<IListener>();
    private bool GameOver = false;
    private Mark WinnerMark = Mark.Unmarked;

    public Mark Get(int column, int row)
    {
        return Board[column, row];
    }

    public void Put(int column, int row, Mark mark)
    {
        if (GameOver)
        {
            Listeners.ForEach(listener => listener.OnPutFailed(column, row, "Game is overed"));
        }

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

        Listeners.ForEach(listener => listener.OnPutSucceeded(column, row, mark));

        CurrentMove++;

        DetectGameOver();
    }

    public Mark GetCurrentTurn()
    {
        return Turns[CurrentMove % Turns.Length];
    }
    
    private void DetectGameOver()
    {
        for (int i = 0; i < GameOverVariants.GetLength(0); i++)
        {
            bool gameOver = true;
            TicTacToeGame.Mark winnerMark = TicTacToeGame.Mark.Unmarked;
            for (int j = 0; j < GameOverVariants.GetLength(1); j++)
            {
                int column = GameOverVariants[i, j, 0];
                int row = GameOverVariants[i, j, 1];
                TicTacToeGame.Mark mark = Get(column, row);
                if (mark == TicTacToeGame.Mark.Unmarked || winnerMark != TicTacToeGame.Mark.Unmarked && mark != winnerMark)
                {
                    gameOver = false;
                    break;
                }
                winnerMark = mark;
            }
            if (gameOver)
            {
                GameOver = true;
                WinnerMark = winnerMark;
                Listeners.ForEach(listener => listener.OnGameOver(winnerMark));
                return;
            }
        }
    }

    public bool IsGameOver()
    {
        return GameOver;
    }

    public Mark GetWinnerMark()
    {
        return WinnerMark;
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
