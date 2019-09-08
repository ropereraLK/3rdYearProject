using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace thushiniMiniSuperProject.InvPurchaseOrder
{
    public class NodePO
    {
        private int proId;
        private string proName;
        private float minPrice;
        private float maxPrice;
        private float minStock;
        private float currentstock;
       // private float forcastedOrder;

        private int replacementTime;//How many days interval the replacement happen usually Eg: in every 7 weeks
        
        private float salesPastSevenDays;


        public NodePO(int proId, String proName, float minPrice, float maxPrice, float minStock, float currentstock,  int replacementTime, float salesPastSevenDays)
        {
            this.proId = proId;
            this.proName = proName;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
            this.minStock = minStock;
            this.currentstock = currentstock;
            //this.forcastedOrder = forcastedOrder;
            this.replacementTime = replacementTime;
            this.salesPastSevenDays = salesPastSevenDays;
        }

        public int getProId()
        {
            return proId;
        }

        public void setProId(int proId)
        {
            this.proId = proId;
        }

        public String getProName()
        {
            return proName;
        }

        public void setProName(String proName)
        {
            this.proName = proName;
        }

        public float getMinPrice()
        {
            return minPrice;
        }

        public void setMinPrice(float minPrice)
        {
            this.minPrice = minPrice;
        }

        public float getMaxPrice()
        {
            return maxPrice;
        }

        public void setMaxPrice(float maxPrice)
        {
            this.maxPrice = maxPrice;
        }

        public float getMinStock()
        {
            return minStock;
        }

        public void setMinStock(float minStock)
        {
            this.minStock = minStock;
        }

        public float getCurrentstock()
        {
            return currentstock;
        }

        public void setCurrentstock(float currentstock)
        {
            this.currentstock = currentstock;
        }

       /* public float getForcastedOrder()
        {
            return forcastedOrder;
        }

        public void setForcastedOrder(float forcastedOrder)
        {
            this.forcastedOrder = forcastedOrder;
        }*/

        public int getReplacementTime()
        {
            return replacementTime;
        }

        public void setReplacementTime(int replacementTime)
        {
            this.replacementTime = replacementTime;
        }

        public float getSalesPastSevenDays()
        {
            return salesPastSevenDays;
        }

        public void setSalesPastSevenDays(float salesPastSevenDays)
        {
            this.salesPastSevenDays = salesPastSevenDays;
        }

    }
}
