using System.Security.Cryptography;
using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Models;

namespace RockPaperScissorsGame
{
    public class Program
    {
        public static bool CheckArgs(string[] args)
        {
            if (args.Length < 3 || args.Length % 2 == 0)
            {
                Console.WriteLine("Invalid parameters: please provide an odd number of parameters (3 or more).");
                return false;
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Invalid options: all parameters must be unique.");
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

            var generatedKey = new KeyGenerator();
            var helpTable = new HelpTable(args);
            var gameDecider = new GameDecider(args.Length);

            bool isGameFinished = false;

            while (!isGameFinished)
            {
                Console.Clear();

                var key = generatedKey.GenerateKey();
                var randomNumber = RandomNumberGenerator.GetInt32(args.Length);
                var hmac = HmacGenerator.GenerateHMAC(key, args[randomNumber]);

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("HMAC: " + hmac);
                Console.ResetColor();

                Console.WriteLine("Available Moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine($"{i + 1} - {args[i]}");
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine("? - Help");

                Console.Write("Enter your move: ");
                var ans = Console.ReadLine();

                if (ans == "?")
                {
                    helpTable.Print();
                    Console.WriteLine("\n\nPress any key to continue");
                    Console.ReadKey();
                    continue;
                }

                if (ans == "0")
                {
                    isGameFinished = true;
                    continue;
                }

                int playerMove = 0;

                if (!int.TryParse(ans, out playerMove) || playerMove <= 0 || playerMove > args.Length)
                {
                    Console.WriteLine("\n\nInvalid move. Press any key to continue");
                    Console.ReadKey();
                    continue;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Your move: " + args[playerMove - 1]);
                Console.ResetColor();
                Console.WriteLine("Computer move: " + args[randomNumber]);

                GameResult result = gameDecider.Decide(randomNumber, playerMove - 1);

                switch (result)
                {
                    case GameResult.WIN:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("You won!");
                        break;

                    case GameResult.LOSE:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You lost!");
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Draw!");
                        break;
                }

                Console.ResetColor();

                Console.WriteLine("HMAC key: " + key);
                Console.WriteLine();
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
    }
}