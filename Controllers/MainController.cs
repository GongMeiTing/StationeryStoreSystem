using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using StationeryStoreSystem.Models;


namespace StationeryStoreSystem.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        StationeryStoreEntities context = new StationeryStoreEntities();
        public ActionResult Create()
        {
            //int number1 = 2000;
            //int number2 = 0;
            //try
            //{
            //    int answer=number1/number2;
            //}
            //catch (DivideByZeroException )
            //{
            //    ViewBag.message="Can not divided by zero";
            //}
            NewOrder neworder = new NewOrder();
            return View(neworder);
        }
        [HttpPost]
        public ActionResult Create(NewOrder neworder)           
        {
            User user = new User();
            List<User> allusers = new List<User>();
            List<string> idlist = new List<string>();
            Order order = new Order();
            Random random = new Random();
            int num = random.Next(10000,90000);
            string userid = neworder.UserID;
            var query = from User in context.Users  select User;
            allusers = query.ToList();
            for(int i = 0; i < allusers.Count; i++)
            {
                idlist.Add(allusers[i].UserID);
            }
            if (idlist.Contains(userid))
            {
                ViewBag.message = "Please provide the unique UserId";
            }else
            {
                user.UserID = neworder.UserID;
                user.UserName = neworder.UserName;
                user.OrderID = num.ToString();
                order.OrderID = user.OrderID;
                order.ItemName = neworder.ItemName;
                order.Quantity = neworder.Quantity;
                order.PricePerItem = neworder.PricePerItem.ToString();
                double test = neworder.PricePerItem * neworder.Quantity;
                order.TotalPrice = test.ToString();
                context.Users.Add(user);
                context.Orders.Add(order);
                context.SaveChanges();
            }

            return View();
        }
    }
}