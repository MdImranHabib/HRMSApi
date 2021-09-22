using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HRMSApi.Models
{
    public class Rent
    {
        public int Id { get; set; }

        [Required]       
        public int FlatId { get; set; }

        [Required]
        [StringLength(15)]        
        public string RentMonth { get; set; }

        [Required]       
        public double FlatRent { get; set; }

        [Required]       
        public double ElectricBill { get; set; }

        [Required]      
        public double GasBill { get; set; }

        [Required]
        public double WaterBill { get; set; }

        [Required]     
        public double TotalBill { get; set; }

        [Required]
        public double Paid { get; set; }

        [Required]       
        public DateTime Date { get; set; }

        [StringLength(200)]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual Flat Flat { get; set; }
    }
}
