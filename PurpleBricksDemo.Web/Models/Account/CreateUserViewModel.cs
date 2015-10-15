using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleBricksDemo.Web.Models.Account
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        [Display(Name = "Username:")]
        [StringLength(100)]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [StringLength(100)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required. please type 'Buyer' or 'Seller'")]
        public string UserRole { get; set; }

    }
}
