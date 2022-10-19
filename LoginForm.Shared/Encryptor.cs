using System.Security.Cryptography;

namespace LoginForm.Shared
{
    public static class Encryptor
    {
        public static string EncryptWithRandomSalt(string password, out byte[] salt)
        {
            RandomNumberGenerator.Fill(salt = new byte[16]);

            return Encrypt(password, salt);
        }

        public static string Encrypt(string password, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string hashedPassword = Convert.ToBase64String(hashBytes);

            return hashedPassword;
        }
    }
}
