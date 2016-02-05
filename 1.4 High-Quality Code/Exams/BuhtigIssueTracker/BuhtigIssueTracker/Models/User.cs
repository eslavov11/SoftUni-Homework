namespace BuhtigIssueTracker.Models
{
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;

    public class User
    {
        public User(string username, string password)
        {
            this.Username = username;
            this.PasswordHash = HashPassword(password);
        }

        public string Username { get; set; }

        public string PasswordHash { get; set; }

        public static string HashPassword(string password)
        {
            return string.Join(
                string.Empty,
                SHA1.Create()
                .ComputeHash(Encoding.Default.GetBytes(password))
                .Select(bytes => bytes.ToString()));
        }
    }
}