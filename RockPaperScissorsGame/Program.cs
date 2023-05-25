namespace RockPaperScissorsGame;

public class Program
{
    static void Main(string[] args)
    {
        if (!ArgumentChecker.CheckArgs(args))
            return;
        
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
            ResultPrinter.PrintOption(args);
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

            Console.WriteLine("\nYour move: " + args[playerMove - 1]+ "\nComputer move: " + args[randomNumber]);

            GameResult result = gameDecider.Decide(randomNumber, playerMove - 1);

            ResultPrinter.ResultPrint(result);

            Console.WriteLine("HMAC key: " + key + "\nPress any key to continue");
            Console.ReadKey();
        }
    }
}