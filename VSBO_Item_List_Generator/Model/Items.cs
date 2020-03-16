using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSBO_Item_List_Generator.Model
{
    class Items
    {
        public string storeID { get; set; }
        public string storeName { get; set; }
        public string itemCode { get; set; }
        public string itemDescription { get; set; }
        public string barcode { get; set; }
        public decimal sellingPrice { get; set; }
        public decimal baseCost { get; set; }
        public decimal netCost { get; set; }
        public decimal averageCost { get; set; }
        public string supplier { get; set; }
        public string department { get; set; }
        public string category { get; set; }
        public string vatType { get; set; }
        public string assortmentType { get; set; }
    }
}
