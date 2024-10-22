using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using System;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(FormData data)
        {
            if (data != null)
            {
                var cookieOptions = new CookieOptions
                {
                    Expires = data.ExpirationDate // Встановлення дати старіння куки
                };
                Response.Cookies.Append("StoredValue", data.Value, cookieOptions);
                return RedirectToAction("CheckCookies");
            }
            return View("Index");
        }

        public IActionResult CheckCookies()
        {
            var value = Request.Cookies["StoredValue"];
            ViewBag.CookieValue = value ?? "Cookie not found";
            return View();
        }
    }
}
