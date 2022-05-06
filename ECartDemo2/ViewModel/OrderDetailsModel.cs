using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECartDemo2.ViewModel
{
    public class OrderDetailsModel
    {
        public Guid OrderDetailId { get; set; }
        public string ImagePath { get; set; }
        public int OrderId { get; set; }
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}