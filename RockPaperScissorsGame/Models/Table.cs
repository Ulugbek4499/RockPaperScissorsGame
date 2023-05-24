using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTables;
using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Models
{
    class Table
    {
        string[] Names;
        public Table(string[] names)
        {
            Names = names;
        }

        public void Print()
        {
            var headerItems = Names.Prepend("PC \\ User");
            var table = new ConsoleTable(headerItems.ToArray());

            var judge = new Judge(Names.Length);

            for (int i = 0; i < Names.Length; i++)
            {
                var currentRow = new string[Names.Length + 1];
                currentRow[0] = Names[i];

                for (int j = 0; j < Names.Length; j++)
                {
                    currentRow[j + 1] = Enum.GetName(typeof(Outcome), judge.Decide(i, j));
                }

                table.AddRow(currentRow.ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}
