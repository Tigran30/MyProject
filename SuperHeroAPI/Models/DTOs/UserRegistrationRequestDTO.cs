using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI.Models.DTOs
{
    public class UserRegistrationRequestDTO
    {
        [Required]
        public string Name { set; get; }
        [Required]
        public string Email { set; get; }
        [Required]
        public string Password { set; get; }
    }
}
