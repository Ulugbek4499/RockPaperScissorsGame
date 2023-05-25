using ConsoleTables;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Models;

class HelpTable
{
    public string[] Names;
    public HelpTable(string[] names)
    {
        Names = names;
    }

    public void Print()
    {
        List<string> headers = new List<string> { "Computer \\ Gamer" };
        headers.AddRange(Names);

        var helpTable = new ConsoleTable(headers.ToArray());
        var GameDecider = new GameDecider(Names.Length);

        for (int i = 0; i < Names.Length; i++)
        {
            var currentRow = new List<string> { Names[i] };

            for (int j = 0; j < Names.Length; j++)
            {
                currentRow.Add(item: Enum.GetName(typeof(GameResult), value: GameDecider.Decide(i, j)));
            }

            helpTable.AddRow(currentRow.ToArray());
        }

        helpTable.Write(Format.Alternative);
    }
}
