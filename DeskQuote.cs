using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MegaDeskRazor
{
    public class DeskQuote
    {
        private const decimal OAK_PRICE = 200.00M;
        private const decimal LAMINATE_PRICE = 100.00M;
        private const decimal PINE_PRICE = 50.00M;
        private const decimal ROSEWOOD_PRICE = 300.00M;
        private const decimal VENEER_PRICE = 125.00M;
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal DRAWER_COST = 50.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;

        public int DeskQuoteId { get; set; }
        public int DeskId { get; set; }
        public string CustomerName { get; set; }
        public DateTime QuoteDate { get; set; }
        public int DeliveryId { get; set; }
    }

}
