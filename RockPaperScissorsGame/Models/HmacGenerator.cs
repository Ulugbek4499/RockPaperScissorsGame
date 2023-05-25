using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissorsGame.Models;

public class HmacGenerator
{
    public static string GenerateHMAC(string key, string message)
    {
        using (HMACSHA256 hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
        {
            byte[] hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
