using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame.Models
{
    internal class Security
    {
        public string GenerateKey()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[16];
            rng.GetBytes(bytes);

            return BitConverter.ToString(bytes).Replace("-", "");
        }

        public string GenerateHMAC(string key, string message)
        {
            var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key));
            var hash = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));

            return BitConverter.ToString(hash).Replace("-", "");
        }
    }
}
