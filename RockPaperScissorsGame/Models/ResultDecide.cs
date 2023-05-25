using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Models;

public class GameDecider
{
    public int MoveCount;

    public GameDecider(int MoveCount) =>
        this.MoveCount = MoveCount;

    public GameResult Decide(int firstMove, int secondMove)
    {
        if (firstMove == secondMove)
            return GameResult.DRAW;

        if ((secondMove > firstMove && secondMove - firstMove <= this.MoveCount / 2) ||
            (secondMove < firstMove && firstMove - secondMove > this.MoveCount / 2))
            return GameResult.WIN;

        return GameResult.LOSE;
    }
}
