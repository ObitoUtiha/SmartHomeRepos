using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SmartHomeApi.Model
{
    public class Registration
    {
        [Required]
        [EmailAddress]
        public string? Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        public int? Role { get; set; }

        //[DataType(DataType.Password)]
        //[Display(Name = "Confirm Password")]
        //[Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
        //public string? ConfirmPassword { get; set; }

        public string? NickName { get; set; }


    }
}
