using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(200)]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Company Type")]
        public int CompanyCategoryId { get; set; }

        //[DataType(DataType.MultilineText)]
        //[StringLength(500)]
        //public string Address { get; set; }

        [Required]
        [EmailAddress]
        //[Remote("IsEmailExist", "Companies", ErrorMessage = "This email is already in use. Please try another.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime RegDate { get; set; }

        //[Display(Name = "Vat/Tax No.")]
        //public string VatNo { get; set; }    

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //public virtual CompanyCategory CompanyCategory { get; set; }
    }
}
