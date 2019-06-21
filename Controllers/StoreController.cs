using CrystalDecisions.CrystalReports.Engine;
using StationeryStoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using System.Dynamic;

namespace StationeryStoreSystem.Controllers
{
    public class StoreController : Controller
    {
        StationeryStoreEntities context = new StationeryStoreEntities();
        public ActionResult Index()
        {
            List<string> colName = new List<string>();
            List<int> colNum = new List<int>();
            var prelist = context.Orders.ToList();
            var Num = (from m in context.Orders
                       group m by m.ItemName into g
                       select g.Sum(m => m.Quantity)
                         ).ToList();
            var Name = (from m in context.Orders
                        group m by m.ItemName into g
                        select g.Key
                         ).ToList();

            List<DataPoint> dataPoints = new List<DataPoint>();
            for (int i = 0; i < Num.Count(); i++)
            {
                colNum.Add(Num[i]);
            }
            for (int i = 0; i < colNum.Count(); i++)
            {
                DataPoint element = new DataPoint(Name[i], colNum[i]);
                dataPoints.Add(element);
            }
            //List<DataPoint> dataPoints = new List<DataPoint>{
            //    new DataPoint("a", 22),
            //    new DataPoint("b", 36),
            //    new DataPoint("c", 42),

            //};
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
        public ActionResult ExportOrders()
        {
            List<Order> allorders = new List<Order>();
            allorders = context.Orders.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"), "StoreReport.rpt"));
            rd.SetDataSource(allorders);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "OrderList.pdf");
        }
        public ActionResult ExportChart()
        {
            List<Order> orders = new List<Order>();
            orders = context.Orders.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/CrystalReports"),"Piechart.rpt"));
            rd.SetDataSource(orders);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);
            return File(stream, "application/pdf", "Summary.pdf");
        }
    }
}