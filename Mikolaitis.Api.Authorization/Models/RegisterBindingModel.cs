using System.ComponentModel.DataAnnotations;

namespace Mikolaitis.Api.Authorization.Models
{
    public class RegisterBindingModel
    {
        [Required]
        [RegularExpression(@"[А-Яа-я ]+", ErrorMessage = "Only cyrillic characters is allowed")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Not a valid email")]
        [StringLength(100, ErrorMessage = "Email is too long")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}