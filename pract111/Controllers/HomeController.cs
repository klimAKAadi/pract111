using System.Linq;
using Microsoft.AspNetCore.Mvc;
using pract111.Models;

namespace pract111.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }
        [HttpGet]
        [Route("{id:int}")]

        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Спасибо, " + order.User + ", за покупку!";
        }
    }
}