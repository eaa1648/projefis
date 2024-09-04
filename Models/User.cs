using System.ComponentModel.DataAnnotations;

namespace projefis.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        public bool IsAdmin { get; set; } // Admin rolü ekleniyor
    }
}
