using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS.Model
{
    public class RegisterViewModel
    {
        [Required]
        public string user { get; set; }

        [Required]
        public string password { get; set; }

        public bool RememberMe { get; set; }
    }

    public class UserRegisterViewModel
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Please Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(25, ErrorMessage = "Password must be between 5 and 25", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Please Confirm Password")]
        [Display(Name = "Confirm Password")]
        [StringLength(25, ErrorMessage = "Password must be between 5 and 25", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please Enter Phone")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Valid Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }

        public UserRegisterViewModel()
        {

        }

        public UserRegisterViewModel(Guid id, string name, string username, string phone, string mail, DateTime dob)
        {
            this.Id = id;
            this.DOB = dob;
            this.Email = mail;
            this.Name = name;
            this.Phone = phone;
            this.UserName = username;
        }
    }

    public class UserListViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string UserName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
