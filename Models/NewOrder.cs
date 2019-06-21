using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StationeryStoreSystem.Models
{
    public class NewOrder
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string OrderID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        public double PricePerItem { get; set; }
        public double TotalPrice { get; set; }

    }
}