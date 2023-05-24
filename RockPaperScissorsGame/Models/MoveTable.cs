using ConsoleTables;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Models;

class MoveTable
{
    public string[] Names;
    public MoveTable(string[] names)
    {
        Names = names;
    }

    public void Print()
    {
        var headerItems = new List<string> { "PC \\ User" };
        headerItems.AddRange(Names);

        var moveTable = new ConsoleTable(headerItems.ToArray());
        var resultDecide = new ResultDecide(Names.Length);

        for (int i = 0; i < Names.Length; i++)
        {
            var currentRow = new List<string> { Names[i] };

            for (int j = 0; j < Names.Length; j++)
            {
                currentRow.Add(item: Enum.GetName(typeof(Result), value: resultDecide.Decide(i, j)));
            }

            moveTable.AddRow(currentRow.ToArray());
        }

        moveTable.Write(Format.Alternative);
    }
}
