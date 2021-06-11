using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        
        [Required]
        public decimal Width { get; set; }
       
        [Required]
        public decimal Depth { get; set; }

        [Display(Name="Number of Drawers")]

        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        [Required]
        public int DesktopMaterialId { get; set; }

        //navegation  propeties
        public DesktopMaterial Material { get; set; }
    }

}
