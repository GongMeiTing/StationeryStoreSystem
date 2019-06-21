using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationeryStoreSystem.Models
{
    public class UpdateOrder
    {
        public string OrderID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public string PricePerItem { get; set; }
        public string TotalPrice { get; set; }
    }
}