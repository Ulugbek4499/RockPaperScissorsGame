using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Models;

public class ResultDecide
{
   public int MovesCount;

    public ResultDecide(int movesCount)=>
        MovesCount = movesCount;
    
    public Result Decide(int firstMove, int secondMove)
    {
        if (firstMove == secondMove)
            return Result.DRAW;
        

        if ((secondMove > firstMove && secondMove - firstMove <= MovesCount / 2) || 
            (secondMove < firstMove && firstMove - secondMove > MovesCount / 2))
           return Result.WIN;
        
        return Result.LOSE;
    }
}
