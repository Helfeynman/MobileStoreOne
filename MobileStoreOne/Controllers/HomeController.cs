using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStoreOne.Models;

namespace MobileStoreOne.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public IActionResult Buy(Order order)
        {
            db.Orders.Add(order);
            var phone = db.Phones.FirstOrDefault(x => order.PhoneId == x.Id);
            if (phone != null)
            {
                db.Phones.Remove(phone);
                db.SaveChanges();
            }

            // сохраняем в бд все изменения
            db.SaveChanges();
            return Redirect("~/Home");
        }
    }
}