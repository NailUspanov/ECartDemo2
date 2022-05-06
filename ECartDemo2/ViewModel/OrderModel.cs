using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECartDemo2.ViewModel
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderNumber { get; set; }
    }
}