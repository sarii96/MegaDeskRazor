using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }

        [Display(Name="Number of Drawers")]
        public int NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        //navegation  propeties
        public DesktopMaterial Material { get; set; }
    }

}
