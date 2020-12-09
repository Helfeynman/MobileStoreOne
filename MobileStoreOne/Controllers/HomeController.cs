using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MobileStoreOne.Models;
using System;
using Microsoft.AspNetCore.Authorization;


namespace MobileStoreOne.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }

        [Authorize]
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

        public IActionResult Change(int? id)
        {
            if (id != null)
            {
                var phone = db.Phones.FirstOrDefault(x => x.Id == id);
                if (phone != null)
                    return View(phone);

            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Change(Phone phone)
        {
            db.Phones.Update(phone);
            db.SaveChanges();
            return Redirect("~/Home");
        }

        public IActionResult AddNew()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Phone phone)
        {
            db.Phones.Add(phone);
            db.SaveChanges();
            return Redirect("~/Home");
        }


        public IActionResult Del(int? id)
        {
            var phone = db.Phones.FirstOrDefault(x => x.Id == id);
            if (id != null)
            {
                db.Phones.Remove(phone);
                db.SaveChanges();
            }

            // сохраняем в бд все изменения
            db.SaveChanges();
            return Redirect("~/Home");
        }




        public IActionResult Duplicate(int? id)
        {
            var phone = db.Phones.FirstOrDefault(x => x.Id == id);
            if (phone != null)
            {
                Phone phone1 = new Phone();
                phone1.Name = phone.Name;
                phone1.Company = phone.Company;
                phone1.Price = phone.Price;

                db.Phones.Add(phone1);
                db.SaveChanges();
            }

            db.SaveChanges();
            return Redirect("~/Home");
        }

        public IActionResult Threeplicate(int? id)
        {
            var phone = db.Phones.FirstOrDefault(x => x.Id == id);
            if (phone != null)
            {
                for(int i = 0; i < 2; i++)
                {
                    Phone phone1 = new Phone();
                    phone1.Name = phone.Name;
                    phone1.Company = phone.Company;
                    phone1.Price = phone.Price;

                    db.Phones.Add(phone1);
                    db.SaveChanges();

                }

            }

            db.SaveChanges();
            return Redirect("~/Home");
        }

        public IActionResult Generate()
        {

                for (int i = 0; i < 3; i++)
                {
                    Phone phone = new Phone();
                    Random rnd = new Random();
                    int priceRnd = rnd.Next(0, 1000);
                    string nameCompanyRnd = "abcdefghijklmn";
                    int RndIndex = rnd.Next(2, 10);

                    phone.Name = new string(Enumerable.Repeat(nameCompanyRnd, RndIndex)
                        .Select(s => s[rnd.Next(s.Length)]).ToArray());

                    phone.Company = new string(Enumerable.Repeat(nameCompanyRnd, RndIndex)
                        .Select(s => s[rnd.Next(s.Length)]).ToArray());

                    phone.Price = priceRnd;

                    db.Phones.Add(phone);
                    db.SaveChanges();

                }

            db.SaveChanges();
            return Redirect("~/Home");



        }


    }

}