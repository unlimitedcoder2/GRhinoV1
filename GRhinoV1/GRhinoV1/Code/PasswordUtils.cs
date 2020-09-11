using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
namespace GRhinoV1.Code
{
	class PasswordUtils
	{
        public static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 0x186A0);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
        public static bool CheckPasssword(string hPassword, string password)
        {
            byte[] hashedPassword = Convert.FromBase64String(hPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashedPassword, 0, salt, 0, 16);
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, 0x186A0);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
            {
                if (hashedPassword[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
