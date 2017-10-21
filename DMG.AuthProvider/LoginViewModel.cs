using System.ComponentModel.DataAnnotations;

namespace DMG.AuthProvider
{
    public class LoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
