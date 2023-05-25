using System.Security.Cryptography;

namespace RockPaperScissorsGame.Models;

public class KeyGenerator
{
    public string GenerateKey()
    {
        using (RandomNumberGenerator randomNumber = RandomNumberGenerator.Create())
        {
            byte[] bytes = new byte[16];
            randomNumber.GetBytes(bytes);
     
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }   
}
