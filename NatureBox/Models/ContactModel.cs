using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NatureBox.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage ="You need to introduce a title")]
        [MinLength(1,ErrorMessage ="Your title is too short. This have to be at least 2 characters")]
        public string Title { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="You need to introduce an email")]
        public string  Expeditor { get; set; }
        [Required(ErrorMessage ="Your messege is empty")]
        [MaxLength(450,ErrorMessage ="Your Messege is too long")]
        public string Messege { get; set; }
    }
}