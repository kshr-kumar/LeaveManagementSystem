using System.ComponentModel.DataAnnotations;

namespace LMMS.UI.Models
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "Please enter the Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "please enter the email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "please enter the password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter the PhoneNumber")]
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }


    }
}
