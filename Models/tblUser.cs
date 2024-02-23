using System;
using System.Collections.Generic;


using System.ComponentModel.DataAnnotations;


using System.Linq;
using System.Threading.Tasks;

namespace SRS.Models
{
    public class tblUser
    {
        // [Display(Name = "UserId")]
        public int c_userid { get; set; }

        [Display(Name = "UserName")]
     //   [Required(ErrorMessage = "Username can't be blank!")]
        public string c_username { get; set; }

        [Display(Name = "Email")]
        // [Required(ErrorMessage = "Email can't be blank!")]
        // [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please Enter a Valid Email!")]
         public string c_email { get; set; }

        [Display(Name = "Password")]
    
        // [DataType(DataType.Password)]
        // [Required(ErrorMessage = "Password can't be blank!")]
         public string c_password { get; set; }

        // [Display(Name = "Confirm Password")]
        // [DataType(DataType.Password)]
        // [Required(ErrorMessage = "Password can't be blank!")]
        // [Compare("c_password", ErrorMessage = "Password and confirm password does not match!")]
         public string c_cpassword { get; set; }
    }
}