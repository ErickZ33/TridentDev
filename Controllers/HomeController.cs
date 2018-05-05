using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TridentDev2.Models;

namespace TridentDev2.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("SubmitForm")]
        public ActionResult SubmitForm(EmailViewModel model)
        {
            return View(model);
        }
    }
}
