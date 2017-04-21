using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lims.DAL;
using Lims.ViewModels;

namespace Lims.Controllers
{
    public class HomeController : Controller
    {
        private StoreContext db = new StoreContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            IQueryable<PurchaseDateGroup> data = from customer in db.Customers
                                                   group customer by customer.PurchaseDate into dateGroup
                                                   select new PurchaseDateGroup()
                                                   {
                                                       PurchaseDate = dateGroup.Key,
                                                       CustomerCount = dateGroup.Count()
                                                   };
            return View(data.ToList());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}