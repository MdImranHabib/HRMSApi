using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]     
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
      
        //public bool RememberMe { get; set; }  

        //public string TokenNumber { get; set; }
    }
}
