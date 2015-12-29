using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class ComputerPlayer : IGameListener
{
    public const double HARDNESS_DUMB = 0;
    public const double HARDNESS_EASY = 0.5;
    public const double HARDNESS_MEDIUM = 0.75;
    public const double HARDNESS_HARD = 1;

    private IGameController GameController;
    private Mark Mark;
    private Random Random;
    private double Hardness;

    public ComputerPlayer(IGameController gameController, Mark mark, Random random, double hardness)
    {
        this.GameController = gameController;
        this.Mark = mark;
        this.Random = random;
        this.Hardness = hardness;
    }

    public void OnGameOver(IGame game, Line winnerLine, Mark winnerMark)
    {

    }

    public void OnPutMark(IGame game, int column, int row, Mark mark)
    {

    }

    public void OnNextPlayerTurn(IGame game, Mark mark)
    {
        if (this.Mark == mark)
        {
            Move(game);
        }
    }

    private void Move(IGame game)
    {
        if (Random.NextDouble() < Hardness)
        {
            foreach (var line in Line.AllPossibleLines)
            {
                int winningMoveIndex = FindMissingIndex(game, line, Mark);
                if (winningMoveIndex >= 0)
                {
                    GameController.RequestPut(line.GetColumn(winningMoveIndex), line.GetRow(winningMoveIndex), Mark);
                    return;
                }
            }
        }

        if (Random.NextDouble() < Hardness)
        {
            foreach (var line in Line.AllPossibleLines)
            {
                int deffenciveMoveIndex = FindMissingIndex(game, line, Mark.Opposite());
                if (deffenciveMoveIndex >= 0)
                {
                    GameController.RequestPut(line.GetColumn(deffenciveMoveIndex), line.GetRow(deffenciveMoveIndex), Mark);
                    return;
                }
            }
        }

        int unmarkedCount = 0;
        for (var r = 0; r < game.RowsAmount; r++)
        {
            for (var c = 0; c < game.ColumnsAmount; c++)
            {
                if (game.GetMark(c, r) == Mark.Unmarked)
                {
                    unmarkedCount++;
                }
            }
        }

        if (unmarkedCount > 0)
        {
            int randomMark = Random.Next(unmarkedCount);
            for (var r = 0; r < game.RowsAmount; r++)
            {
                for (var c = 0; c < game.ColumnsAmount; c++)
                {
                    if (game.GetMark(c, r) == Mark.Unmarked)
                    {
                        if (randomMark == 0)
                        {
                            GameController.RequestPut(c, r, Mark);
                            return;
                        }
                        randomMark--;
                    }
                }
            }
        }
    }

    private int FindMissingIndex(IGame game, Line line, Mark mark)
    {
        int index = -1;
        for (var i = 0; i < Line.Size; i++)
        {
            Mark currentMark = game.GetMark(line.GetColumn(i), line.GetRow(i));
            if (currentMark == Mark.Unmarked)
            {
                if (index < 0)
                {
                    index = i;
                }
                else
                {
                    return -1; // More than 1 mark is Unmarked
                }
            }
            else if (currentMark != mark)
            {
                return -1;
            }
        }
        return index;
    }
}
