using System.ComponentModel.DataAnnotations;

namespace IssueTrackingApi.Models
{
    public class User
    {
        public int Id { get; set; }
        [Key]
        public string Username { get; set; } = string.Empty;
        public Byte[] PasswordHash { get; set; }
        public Byte[] PasswordSalt { get; set; }
    }
}
