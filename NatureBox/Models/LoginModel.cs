using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NatureBox.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage ="You need to enter a username!")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="You need to enter your password!")]
        public string Password { get; set; }

        public string Errormessege { get; set; }
    }
}