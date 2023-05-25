namespace RockPaperScissorsGame.Extensions
{
    public class ResultPrinter
    {
        public static void ResultPrint(GameResult result)
        {
            switch (result)
            {
                case GameResult.WIN:
                    Console.WriteLine("You won!");
                    break;

                case GameResult.LOSE:
                    Console.WriteLine("You lost!");
                    break;

                default:
                    Console.WriteLine("Draw!");
                    break;
            }
        }

        public static void PrintOption(string[] args)
        {
            Console.WriteLine("Available Moves:");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {args[i]}");
            }
            Console.WriteLine("0 - Exit\n? - Help");

            Console.Write("Enter your move: ");
        }
    }
}
