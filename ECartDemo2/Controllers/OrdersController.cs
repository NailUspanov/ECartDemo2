using ECartDemo2.Models;
using ECartDemo2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECartDemo2.Controllers
{
    public class OrdersController : Controller
    {
        private ECartDBEntities objECartDbEntities;
        private List<OrderDetailsModel> listOfOrderDetailsModel;
        public OrdersController()
        {
            objECartDbEntities = new ECartDBEntities();
            listOfOrderDetailsModel = new List<OrderDetailsModel>();
        }
        // GET: Orders
        public ActionResult Index()
        {
            IEnumerable<OrderDetailsModel> listOfOrderDetailsModel = (from objCate in objECartDbEntities.Items
                                                                      join
                                                                           objItem in objECartDbEntities.OrderDetails
                                                                           on objCate.ItemId.ToString() equals objItem.ItemId
                                                                       select new OrderDetailsModel()
                                                                       {
                                                                           ImagePath = objCate.ImagePath,
                                                                           ItemName = objCate.ItemName,
                                                                           OrderId = objItem.OrderId,
                                                                           ItemId = objItem.ItemId,
                                                                           Quantity = objItem.Quantity,
                                                                           UnitPrice = objItem.UnitPrice,
                                                                           Total = objItem.Total
                                                                       }

                ).ToList();
            return View(listOfOrderDetailsModel);
        }


    }
}