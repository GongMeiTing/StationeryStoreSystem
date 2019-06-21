using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using StationeryStoreSystem.Models;

namespace StationeryStoreSystem.Controllers
{
    //[RoutePrefix("api/values")]
    public class TestController : ApiController
    {
        [Route("api/Test/GetOrderById/{moduleid}")]
        public IHttpActionResult GetOrderById(string moduleid)
        {
            StationeryStoreEntities context = new StationeryStoreEntities();
            var order = context.Orders.Where(s => s.OrderID == moduleid).FirstOrDefault<Order>();
            return Ok(order);
        }

        [Route("api/Test/InsertOrder/{neworder}")]
        [HttpPost]
        public IHttpActionResult InsertOrder(NewOrder neworder)
        {
            StationeryStoreEntities context = new StationeryStoreEntities();
            User user = new User();
            Order order = new Order();
            user.UserID = neworder.UserID;
            user.UserName = neworder.UserName;
            Random random = new Random();
            int num = random.Next(10000, 90000);
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
            return Ok(order); ;
        }

        [Route("api/Test/Delete/{order}")]
        //[Route("api/Test/Delete")]
        [HttpPost]
        public string Delete(Order order)
        {

            StationeryStoreEntities context = new StationeryStoreEntities();
            string id = order.OrderID;
            var ordered = context.Orders.Where(s => s.OrderID == id).FirstOrDefault<Order>();
            var user = context.Users.Where(s => s.OrderID == id).FirstOrDefault<User>();
            context.Orders.Remove(ordered);
            context.Users.Remove(user);
            context.SaveChanges();
            return "hello";
        }

        [Route("api/Test/update/{changed}")]
        //[Route("api/Test/update")]
        [HttpPost]
        public string update(Order changed)
        {
            StationeryStoreEntities ctx = new StationeryStoreEntities();
            string id = changed.OrderID;
            var order = ctx.Orders.Where(s => s.OrderID == id).FirstOrDefault<Order>();
            order.Quantity = changed.Quantity;
            order.PricePerItem = changed.PricePerItem;
            order.ItemName = changed.ItemName;
            double price = Double.Parse(changed.PricePerItem) * changed.Quantity;
            order.TotalPrice = price.ToString();
            ctx.SaveChanges();
            return "Changed";
        }

        [Route("api/Test/CreateOrder/{id}")]
        [HttpGet]
        public string CreateOrder(string id)
        {
            StationeryStoreEntities context = new StationeryStoreEntities();
            User user = new User();
            Order order = new Order();
            user.UserID = "3000000000001111";
            user.OrderID = id;
            user.UserName = "mm1111111111111111";
            user.Order = order;
            order.OrderID = user.OrderID;
            order.ItemName = "Pen";
            order.Quantity = 2;
            order.PricePerItem = "1.5";                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            order.TotalPrice = "3";
            context.Users.Add(user);
            context.Orders.Add(order);
            context.SaveChanges();
            return "Hello";
        }


    }
}
