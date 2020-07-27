using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NatureBox.Models
{
    public class RegisterModel
    {
        [Display(Name ="First Name")]
        [Required(ErrorMessage ="You need to give us your first name")]
        [StringLength(50,MinimumLength =1,ErrorMessage ="Your username has to have 5-20 characters.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your last name")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Your username has to have 5-20 characters.")]
        public string LastName { get; set; }

        [Required(ErrorMessage ="You need to give us your email.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
 
        [Required(ErrorMessage ="You need to confirm your email.")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email",ErrorMessage ="Your email and confirm email doesn't match")]
        [Display(Name ="Confirm Email")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="You need a password")]
        [StringLength(30,MinimumLength =8,ErrorMessage ="Your password should be between 8 and 30 characters long")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="You need to confirm your password")]
        [Compare("Password",ErrorMessage ="Your password and confirm password doesn't match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string ErrorMessege { get; set; }

    }
}