using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thushiniMiniSuperProject
{
    public class PurchaseOrderNode
    {
        
        string nodeProductId;
        string nodeProductName;
        float nodeProductMinPrice;
        float nodeProductMaxPrice;
        float nodeProductMinStock;
        float nodeProductCurrentStock;
        int nodeProductNextReplacement;
        float nodeProductAverageSales;
        int nodeProductLastRecieved;
        float nodeProductForecastedOrder;
        float nodeProductPlacedOrder;

        public PurchaseOrderNode(string nodeProductId,
            string nodeProductName,
            float nodeProductMinPrice,
            float nodeProductMaxPrice,
            float nodeProductMinStock,
            float nodeProductCurrentStock,
            int nodeProductNextReplacement,
            float nodeProductAverageSales,
            int nodeProductLastRecieved,
            float nodeProductForecastedOrder,
            float nodeProductPlacedOrder)
                {
                    this.nodeProductId = nodeProductId;
                    this.nodeProductName = nodeProductName;
                    this.nodeProductMinPrice = nodeProductMinPrice;
                    this.nodeProductMaxPrice = nodeProductMaxPrice;
                    this.nodeProductMinStock = nodeProductMinStock;
                    this.nodeProductCurrentStock = nodeProductCurrentStock;
                    this.nodeProductNextReplacement = nodeProductNextReplacement;
                    this.nodeProductAverageSales = nodeProductAverageSales;
                    this.nodeProductLastRecieved = nodeProductLastRecieved;
                    this.nodeProductForecastedOrder = nodeProductForecastedOrder;
                    this.nodeProductPlacedOrder = nodeProductPlacedOrder;

                }


    }
}
