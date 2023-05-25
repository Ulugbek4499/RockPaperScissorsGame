namespace RockPaperScissorsGame.Extensions
{
    public static class ArgumentChecker
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
    }
}
