using System.ComponentModel.DataAnnotations;

namespace User.Managment.API.Models.Signup
{
    public class RegisterUser
    {
        [Required(ErrorMessage ="Username is required.")]
        public string? Username { get; set; }
        [Required(ErrorMessage ="Email is required.")]
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        public string? Password { get; set; }
    }
}
