using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models
{
    public class Resident
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]     
        public string Name { get; set; }

        [EmailAddress]      
        [StringLength(100)]
        //[Remote("IsEmailExist", "Residents", ErrorMessage = "This email is already in use. Please try another.")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [Phone]       
        [StringLength(15, MinimumLength = 11)]       
        public string ContactNo { get; set; }

        [Required]
        [StringLength(17)]       
        public string NIDNo { get; set; }
       
        public string PhotoPath { get; set; }

        [Required]
        [StringLength(100)]
        public string Occupation { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]   
        public string PrevAddress { get; set; }

        public double OpeningBalance { get; set; }
    }
}
