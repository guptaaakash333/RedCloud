using System.ComponentModel.DataAnnotations;

namespace RedCloud.Models.Account
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Please enter Password")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^a-zA-Z\\d]).{6,}$", ErrorMessage = "Password must be of 6 character and include atleast 1 Uppercase , 1 AlphaNumeric value and 1 special character.")]
        public string Password { get; set; }
    }
}
