using System.Security.Cryptography;
using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Models;

public class Program
{
    public static bool CheckArgs(string[] args)
    {
        if (args.Length < 3 || args.Length % 2 == 0)
        {
            Console.WriteLine("Invalid options: please provide an odd number of moves (3 or more).");
            return false;
        }

        if (args.Length != args.Distinct().Count())
        {
            Console.WriteLine("Invalid options: all moves must be unique.");
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

        var sec = new KeyGenerator();
        var a = new MoveTable(args);
        var ResultDecide = new ResultDecide(args.Length);

        bool gameFinished = false;

        while (!gameFinished)
        {
            Console.Clear();
            var key = sec.GenerateKey();
            var randomNumber = RandomNumberGenerator.GetInt32(args.Length);
            var hmac = sec.GenerateHMAC(key, args[randomNumber]);

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
            Console.WriteLine("Computer move: " + args[randomNumber]);

            switch (ResultDecide.Decide(randomNumber, playerMove - 1))
            {
                case Result.WIN:
                    Console.WriteLine("You won!");
                    break;

                case Result.LOSE:
                    Console.WriteLine("You lost!");
                    break;

                default:
                    Console.WriteLine("Draw!");
                    break;
            }

            Console.WriteLine("HMAC key: " + key);
            Console.Write("\n\n");

            Console.WriteLine("Press the key to continue");
            Console.ReadKey();
        }
    }
}