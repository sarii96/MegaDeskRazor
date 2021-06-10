using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MegaDeskRazor.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
 
        [Display(Name = "Delivery Type")]
        public string DeliveryType { get; set; }
        public decimal LessThan1000 { get; set; }
        public decimal Between1000and2000 { get; set; }
        public decimal GreatherThan2000 { get; set; }
    }
}
