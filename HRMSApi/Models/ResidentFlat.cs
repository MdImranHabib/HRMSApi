using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models
{
    public class ResidentFlat
    {
        public int Id { get; set; }

        [Required]       
        public int ResidentId { get; set; }

        [Required]        
        public int FlatId { get; set; }

        [Required]
        [DataType(DataType.Date)]       
        public DateTime ArrivalDate { get; set; }

        [DataType(DataType.Date)]       
        public DateTime? DepartureDate { get; set; }

        public virtual Resident Resident { get; set; }
        public virtual Flat Flat { get; set; }
    }
}
