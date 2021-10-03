using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HRMSApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(70)]
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ResidentId { get; set; }          
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual Resident Residents { get; set; }
    }
}
