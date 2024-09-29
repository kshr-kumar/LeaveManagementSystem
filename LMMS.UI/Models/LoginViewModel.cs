using System.ComponentModel.DataAnnotations;

namespace LMMS.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter password")]
        public string Password { get; set; }
    }
}
    