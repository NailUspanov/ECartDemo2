using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECartDemo2.Models;
using ECartDemo2.ViewModel;

namespace ECartDemo2.Controllers
{
    public class ItemController : Controller
    {
        private ECartDBEntities objECartDbEntities;
        private List<ShoppingCartModel> listOfShoppingCartModels;
        public ItemController()
        {
            objECartDbEntities = new ECartDBEntities();
            listOfShoppingCartModels = new List<ShoppingCartModel>();
        }
 
        // GET: Item
        [Authorize]
        public ActionResult Index()
        {
            ItemViewModel objItemViewModel = new ItemViewModel();
            objItemViewModel.CategorySelectListItem = (from objCat in objECartDbEntities.Categories
                                                       select new SelectListItem()
                                                       {
                                                           Text = objCat.CategoryName,
                                                           Value = objCat.CategoryId.ToString(),
                                                           Selected = true
                                                       });
            return View(objItemViewModel);
        }

        [HttpPost]
        public JsonResult Index(ItemViewModel objItemViewModel)
        {

            Item item = objECartDbEntities.Items.SingleOrDefault(i => i.ItemCode == objItemViewModel.ItemCode);
            if (item == null)
            {
                string NewImage = Guid.NewGuid() + Path.GetExtension(objItemViewModel.ImagePath.FileName);
                objItemViewModel.ImagePath.SaveAs(Server.MapPath("~/Images/" + NewImage));

                Item objItem = new Item();
                objItem.ImagePath = "~/Images/" + NewImage;
                objItem.CategoryId = objItemViewModel.CategoryId;
                objItem.Description = objItemViewModel.Description;
                objItem.ItemCode = objItemViewModel.ItemCode;
                objItem.ItemId = Guid.NewGuid();
                objItem.ItemName = objItemViewModel.ItemName;
                objItem.ItemPrice = objItemViewModel.ItemPrice;
                objItem.Quantity = objItemViewModel.Quantity;

                objECartDbEntities.Items.Add(objItem);
                objECartDbEntities.SaveChanges();

                return Json(new { Success = true, Message = "Item is added Successfully." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                item.CategoryId = objItemViewModel.CategoryId;
                item.Description = objItemViewModel.Description;
                item.ItemCode = objItemViewModel.ItemCode;
                item.ItemName = objItemViewModel.ItemName;
                item.ItemPrice = objItemViewModel.ItemPrice;
                item.Quantity = objItemViewModel.Quantity;
                objECartDbEntities.SaveChanges();

                return Json(new { Success = true, Message = "Item is updated Successfully." }, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}