using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;


namespace MegaDeskRazor
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
        public string CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public int DeliveryId { get; set; }
        public decimal QuotePrice { get; set; }

        //navigation  properties
        public Desk Desk { get; set; }
        public Delivery DeliveryType { get; set; }

        //methods
        public decimal GetQuotePrice()
        {
            // getRushOrderPrices();
            decimal quotePrice = BASE_DESK_PRICE;

            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;

            decimal surfacePrice = 0.00M;

            if (surfaceArea > 1000)
            {
                surfacePrice = (surfaceArea - 1000) * SURFACE_AREA_COST;
            }

            decimal drawerPrice = this.Desk.NumberOfDrawers * DRAWER_COST;

            decimal surfaceMaterialPrice = 0.00M;

            //switch (this.Desk.Material)
            //{
            //    case DesktopMaterial.Laminate:
            //        surfaceMaterialPrice = LAMINATE_COST;
            //        break;

            //    case DesktopMaterial.Oak:
            //        surfaceMaterialPrice = OAK_COST;
            //        break;

            //    case DesktopMaterial.Pine:
            //        surfaceMaterialPrice = PINE_COST;
            //        break;

            //    case DesktopMaterial.Rosewood:
            //        surfaceMaterialPrice = ROSEWOOD_COST;
            //        break;

            //    case DesktopMaterial.Veneer:
            //        surfaceMaterialPrice = VENEER_COST;
            //        break;
            //}

            decimal shippingPrice = 0.00M;

            //// switch (this.DeliveryType)
            // {
            //     case Delivery.Rush3Days:
            //         if (surfaceArea < 1000)
            //     {
            //         shippingPrice = _rushOrderPrices[0, 0];
            //     }
            //         else if (surfaceArea <= 2000)
            // {
            //        shippingPrice = _rushOrderPrices[0, 1];
            // }
            //else
            //{
            //    shippingPrice = _rushOrderPrices[0, 2];
            //}
            //break;

            // case Delivery.Rush5Days:
            //         if (surfaceArea < 1000)
            //     {
            //         shippingPrice = _rushOrderPrices[1, 0];
            //     }
            //         else if (surfaceArea <= 2000)
            // {
            //        shippingPrice = _rushOrderPrices[1, 1];
            // }
            //else
            //{
            //    shippingPrice = _rushOrderPrices[1, 2];
            //}
            //break;

            // case Delivery.Rush7Days:
            //         if (surfaceArea < 1000)
            //     {
            //         shippingPrice = _rushOrderPrices[2, 0];
            //     }
            //         else if (surfaceArea <= 2000)
            // {
            //        shippingPrice = _rushOrderPrices[2, 1];
            // }
            //else
            //{
            //    shippingPrice = _rushOrderPrices[2, 2];
            //}
            //break;

            //}
            quotePrice = quotePrice + surfacePrice + drawerPrice + surfaceMaterialPrice + shippingPrice;
            return quotePrice;
        }
    }

}
 