using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {
        //private const decimal OAK_PRICE = 200.00M;
        //private const decimal LAMINATE_PRICE = 100.00M;
        //private const decimal PINE_PRICE = 50.00M;
        //private const decimal ROSEWOOD_PRICE = 300.00M;
        //private const decimal VENEER_PRICE = 125.00M;
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal DRAWER_COST = 50.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;

        public int DeskQuoteId { get; set; }
        public int DeskId { get; set; }

        [Display(Name = " Customer Name")]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get; set; }
        public int DeliveryId { get; set; }

        [Display(Name = "Quote Price")]
        public decimal QuotePrice { get; set; }

        //navigation  properties
        public Desk Desk { get; set; }

        [Display(Name = "Delivery Type")]
        public Delivery DeliveryType { get; set; }

        //methods
        public decimal GetQuotePrice(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            decimal quotePrice = BASE_DESK_PRICE;

            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;

            decimal surfacePrice = 0.00M;

            if (surfaceArea > 1000)
            {
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_COST;
            }

            decimal drawerPrice = this.Desk.NumberOfDrawers * DRAWER_COST;

            decimal surfaceMaterialPrice = 0.00M;
            var surfaceMaterialPrices = context.DesktopMaterial.Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId).FirstOrDefault();
            surfaceMaterialPrice = surfaceMaterialPrices.DesktopMaterialPrice;

            decimal shippingPrice = 0.00M;
            var shippingPrices = context.Delivery.Where(d => d.DeliveryId == this.DeliveryId).FirstOrDefault();

            if (surfaceArea < 1000)
            {
                shippingPrice = shippingPrices.LessThan1000;
            } 
            else if (surfaceArea >= 1000 || surfaceArea <= 2000)
            {
                shippingPrice = shippingPrices.Between1000and2000;
            }
            else
            {
                shippingPrice = shippingPrices.GreatherThan2000;
            }
          

            quotePrice = quotePrice + surfacePrice + drawerPrice + surfaceMaterialPrice + shippingPrice;
            return quotePrice;
        }
    }

}
 