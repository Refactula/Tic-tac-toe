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
            Console.Write("Game overed: ");
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
            for (var r = 0; r < Game.Rows; r++)
            {
                for (var c = 0; c < Game.Columns; c++)
                {
                    Mark m = game.Get(c, r);
                    char ch = m == Mark.Cross ? 'X' : m == Mark.Nought ? '0' : ' ';
                    Console.Write(ch);
                    if (c < Game.Columns - 1)
                    {
                        Console.Write('|');
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }
                if (r < Game.Rows - 1)
                {
                    for (int i = 0; i < Game.Columns * 2 - 1; i++) {
                        Console.Write('-');
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
