using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models.DTOs
{
    public class UserLoignRequestDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
