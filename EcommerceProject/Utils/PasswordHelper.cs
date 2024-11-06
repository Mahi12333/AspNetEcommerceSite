using System.Security.Cryptography;
using System.Text;

namespace EcommerceProject.Utils
{
    public class PasswordHelper
    {
        // Hash the password using SHA256
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert bytes to hex string
                }
                return builder.ToString();
            }
        }

        // Compare a plain password with a hashed one
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            string enteredHash = HashPassword(enteredPassword);
            return storedHash == enteredHash;
        }
    }
}
