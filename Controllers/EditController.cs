using StationeryStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StationeryStoreSystem.Controllers
{
    public class EditController : Controller
    {
        // GET: Edit
        StationeryStoreEntities ctx = new StationeryStoreEntities();
        public ActionResult Edit()
        {
            
            List<Order> allorders = new List<Order>();
            var query = from Order in ctx.Orders orderby Order.OrderID ascending select Order;
            allorders = query.ToList();
            return View(allorders);
        }
        public ActionResult Delete(string passid)
        {
            
            var order = ctx.Orders.Where(s => s.OrderID == passid).FirstOrDefault<Order>();
            var user = ctx.Users.Where(s => s.OrderID == passid).FirstOrDefault<User>();
            ctx.Orders.Remove(order);
            ctx.Users.Remove(user);
            ctx.SaveChanges();
            return Redirect("/Edit/Edit");
        }
        //public ActionResult Update()
        //{

        //    String passid = (TempData["id"]).ToString();
        //    String name = (TempData["name"]).ToString();
        //    String quantity = (TempData["qty"]).ToString();
        //    var order = ctx.Orders.Where(s => s.OrderID == passid).FirstOrDefault<Order>();

        //    ctx.SaveChanges();
        //    return Redirect("/Edit/Edit");
        //}
        [HttpPost]
        public ActionResult Edit (List<Order> changedorders,string submit)
        {

            List<string> orderid = new List<string>();
            for(int i=0;i<changedorders.Count(); i++)
            {
                orderid.Add(changedorders[i].OrderID);
            }
            for(int i = 0; i < orderid.Count(); i++)
            {
                if (submit == orderid[i])
                {
                    var order = ctx.Orders.Where(s => s.OrderID == submit).FirstOrDefault<Order>();
                    order.ItemName = changedorders[i].ItemName;
                    order.Quantity= changedorders[i].Quantity;
                    order.PricePerItem = changedorders[i].PricePerItem;
                    double price = Double.Parse(changedorders[i].PricePerItem) * changedorders[i].Quantity;
                    order.TotalPrice = price.ToString();
                    ctx.SaveChanges();
                }
            }
            //return Content("<script language='javascript' type='text/javascript'>alert('Thanks for Feedback!'););</script>");
             return Redirect("/Edit/Edit");
        }
    }
}