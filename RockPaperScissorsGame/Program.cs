using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Models;
using System.Security.Cryptography;

class Program
{
    static bool CheckArgs(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Invalid options: please pass odd number of moves (3 or more).");
            return false;
        }

        if (args.Length != args.Distinct().Count())
        {
            Console.WriteLine("Invalid options: all moves must be distinct.");
            return false;
        }

        return true;
    }

    static void Main(string[] args)
    {
        if (!CheckArgs(args))
        {
            return;
        }

        var sec = new Security();
        var a = new Table(args);
        var judge = new Judge(args.Length);

        bool gameFinished = false;

        while (!gameFinished)
        {
            var key = sec.GenerateKey();
            var computerMove = RandomNumberGenerator.GetInt32(args.Length);
            var hmac = sec.GenerateHMAC(key, args[computerMove]);

            Console.WriteLine("HMAC: " + hmac);

            Console.WriteLine("Available Moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + args[i]);
            }
            Console.WriteLine("0 - Exit");
            Console.WriteLine("? - Help");

            Console.Write("Enter your move: ");
            var ans = Console.ReadLine();

            if (ans == "?")
            {
                a.Print();
                Console.Write("\n\n\n");
                continue;
            }

            if (ans == "0")
            {
                gameFinished = true;
                continue;
            }

            int playerMove = 0;

            if (!int.TryParse(ans, out playerMove) || playerMove <= 0 || playerMove > args.Length)
            {
                Console.Write("\n\n\n");
                continue;
            }

            Console.WriteLine("Your move: " + args[playerMove - 1]);
            Console.WriteLine("Computer move: " + args[computerMove]);

            switch (judge.Decide(computerMove, playerMove - 1))
            {
                case Outcome.WIN:
                    Console.WriteLine("You won!");
                    break;

                case Outcome.LOSE:
                    Console.WriteLine("You lost!");
                    break;

                default:
                    Console.WriteLine("Draw!");
                    break;
            }

            Console.WriteLine("HMAC key: " + key);
            Console.Write("\n\n\n");
        }
    }
}