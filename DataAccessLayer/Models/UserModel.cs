using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is required fielld")]
        [MaxLength(20, ErrorMessage ="Name should be not more then 20 charectors")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required fielld")]
        [EmailAddress(ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required fielld")]
        [MinLength(6, ErrorMessage ="Password should be at least 6 charectors")]
        public string Password { get; set; }


    }
}
