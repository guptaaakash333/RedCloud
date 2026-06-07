using System.ComponentModel.DataAnnotations;

namespace RedCloud.ViewModel
{
    public class ForgetUserPasswordVM
    {
        [Required(ErrorMessage = "Please enter Email")]
        [EmailAddress]
        public string Email { get; set; }

        //public string? Password { get; set; }
    }
}
