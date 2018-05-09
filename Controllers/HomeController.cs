using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options; // for secure json read

using TridentDev2.Models;
using static TridentDev2.Models.EmailInfo;
using static TridentDev2.Models.Email;

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
            if(ModelState.IsValid)
            {

                //NOTE: Send confirmation email!!!

                var ptn_addr = model.Email_Address; // potential client address

                string tri_subject = "Project Information";
                string tri_body = $"Brief description of potential project: \n{model.Description}\n\n" +
                            $"Contact information: \n" +
                            $"First Name: {model.First_Name}\n" +
                            $"Last Name: {model.Last_Name}\n" +
                            $"Email Address: {ptn_addr}";

                Email.Send(EmailInfo.User, tri_subject, tri_body); // Tridents copy

                string ptn_subject = "Trident Development - Project Details";
                string ptn_body = $"Hello {model.First_Name} {model.Last_Name},\n\n" + 
                                $"We've received the information regarding your project.  Give us a couple days to get back to you." + 
                                $"If you'd like to get in contact with us personally you can reach Carlos at jcarlosfloresortiz@gmail.com, " + 
                                $"Erick at EricksEmail@email.com, or Darryl at DarrylsEmail@email.com" + 
                                $"Thank you for considering us!\n" + "-Team Trident\n\n" + 
                                $"This is an automatically generated email, DOT NOT REPLY";

                Email.Send(ptn_addr, ptn_subject, ptn_body); // prospect confirmation email

                EmailViewModel blank_model = new EmailViewModel { };
                return View(blank_model);
            }

            else
                return View(model);
        }
    }
}

