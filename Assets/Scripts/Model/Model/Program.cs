using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var game = new GameController();

        Console.ReadKey();
    }

    class GameController : IGameController
    {
        private Game game = new Game();

        public GameController()
        {
            game.Subscribe(new ConsoleLogger());
            game.Subscribe(new ComputerPlayer(this, Mark.Cross, new Random(), ComputerPlayer.HARDNESS_DUMB));
            game.Subscribe(new ComputerPlayer(this, Mark.Nought, new Random(), ComputerPlayer.HARDNESS_HARD));
            game.Start();
        }

        public void RequestPut(int column, int row, Mark mark)
        {
            game.Put(column, row, mark);
        }

    }

    class ConsoleLogger : IGameListener
    {
        public void OnGameOver(IGame game, Line winnerLine, Mark winnerMark)
        {
            Console.Write("Game overred: ");
            if (winnerMark != Mark.Unmarked)
            {
                Console.WriteLine("the winner is " + winnerMark);
            }
            else
            {
                Console.WriteLine("draw");
            }
        }

        public void OnNextPlayerTurn(IGame game, Mark mark)
        {
            Console.WriteLine("Next player: " + mark);
        }

        public void OnPutMark(IGame game, int column, int row, Mark mark)
        {
            for (var r = 0; r < game.RowsAmount; r++)
            {
                for (var c = 0; c < game.ColumnsAmount; c++)
                {
                    Mark m = game.GetMark(c, r);
                    char ch = m == Mark.Cross ? 'X' : m == Mark.Nought ? '0' : ' ';
                    Console.Write(ch);
                    if (c < game.ColumnsAmount - 1)
                    {
                        Console.Write('|');
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                if (r < game.RowsAmount - 1)
                {
                    for (int i = 0; i < game.ColumnsAmount * 2 - 1; i++) {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
