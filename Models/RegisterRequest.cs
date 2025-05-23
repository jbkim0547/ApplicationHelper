using System.ComponentModel.DataAnnotations;

namespace ApplicationHelper.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string Name { get; set; }
    }
}
