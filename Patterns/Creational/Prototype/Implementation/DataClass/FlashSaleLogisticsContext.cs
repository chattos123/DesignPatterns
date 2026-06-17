using System;
using System.Collections.Generic;

namespace Patterns.Creational.Prototype.Implementation.DataClass
{
    internal class FlashSaleLogisticsContext
    {
        public string BatchWarehouseId { get; set; }
        public string ShippingCarrierCode { get; set; }
        public string GlobalPromoCode { get; set; }

        public FlashSaleLogisticsContext(string warehouseId, string carrier, string promo)
        {
            BatchWarehouseId = warehouseId;
            ShippingCarrierCode = carrier;
            GlobalPromoCode = promo;
        }
    }
}
