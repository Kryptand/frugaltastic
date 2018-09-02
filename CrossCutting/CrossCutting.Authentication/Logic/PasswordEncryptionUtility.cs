using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace CrossCutting.Authentication.Logic
{
    public static class PasswordEncryptionUtility
    {
        public static byte[] GenerateSalt()
        {
            var salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }
        public static string GenerateHash(string password,byte[] salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public static bool ValidateHash(string storedPassword,string enteredPassword,string salt)
        {
            var hashBytes = Convert.FromBase64String(storedPassword);
            var saltBytes = Convert.FromBase64String(salt);
            var hashedPassword=Convert.FromBase64String(GenerateHash(enteredPassword, saltBytes));
            /* Compute the hash on the password the user entered */
            return hashedPassword.Length == hashBytes.Length &&
                   !hashedPassword.Where((t, i) => t != hashBytes[i]).Any();
        }
    }
}
