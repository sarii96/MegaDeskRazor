using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace MegaDeskRazor
{
    public class Desk
    {
        public int DeskId { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }

        public int NumberOfDrawers { get; set; }

        public int DesktopMaterialId { get; set; }

        //navegation  propeties
        public DesktopMaterial Material { get; set; }
    }

}
