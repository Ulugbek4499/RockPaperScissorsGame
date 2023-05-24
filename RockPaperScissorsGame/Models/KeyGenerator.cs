using System.Security.Cryptography;
using System.Text;

namespace RockPaperScissorsGame.Models;

public class KeyGenerator
{
    public string GenerateKey()
    {
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);
            return BitConverter.ToString(bytes).Replace("-", "");
        }
    }

    public string GenerateHMAC(string key, string message)
    {
        using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
        {
            byte[] hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
