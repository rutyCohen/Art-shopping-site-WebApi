using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        //public User()
        //{
        //    Orders = new HashSet<Order>();
        //}
        public int UserId { get; set; }
        [EmailAddress (ErrorMessage ="כתובת המייל אינה חוקית")]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MinLength(5,ErrorMessage ="הסיסמא חייבת להכיל 5 תווים לכל הפחות")]
        public string Password { get; set; }
    }
}
