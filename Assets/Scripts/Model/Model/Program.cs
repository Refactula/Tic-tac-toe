using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        var game = new Game();

        game.Subscribe(new ConsoleLogger());
        game.Subscribe(new ComputerPlayer(Mark.Nought));

        game.Put(0, 0, Mark.Cross);
        game.Put(1, 0, Mark.Cross);
        game.Put(2, 0, Mark.Cross);

        Console.ReadKey();
    }

    class ConsoleLogger : IGameListener
    {
        public void OnGameOver(Game game, Line winnerLine)
        {
            Console.WriteLine("Game overed");
        }

        public void OnNextPlayerTurn(Game game, Mark mark)
        {
            Console.WriteLine("Next player: " + mark);
        }

        public void OnPutMark(Game game, int column, int row, Mark mark)
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
