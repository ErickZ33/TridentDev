using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options; // for secure json read

using TridentDev2.Models;
using TridentDev2.Properties;

using System.Net; // NetworkCredential
using System.Net.Mail; // email lib
using static TridentDev2.Models.EmailInfo;


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
                //IOptions<EmailOptions> EmailConfig;

                var from_addr = model.Email_Address;
                var to_addr = new MailAddress(EmailInfo.User, $"{from_addr}");
                Console.WriteLine(EmailInfo.User);

                //const string to_pass = "Tr1d3ntD3v";
                string subject = "Project Information";
                string body = $"Brief description of possible project: \n{model.Description}\n\n" +
                            $"Contact information: \n" +
                            $"First Name: {model.First_Name}\n" +
                            $"Last Name: {model.Last_Name}\n" +
                            $"Email Address: {from_addr}";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(to_addr.Address, EmailInfo.Pass),
                    Timeout = 20000
                };

                using (var message = new MailMessage(to_addr, to_addr) // send it to ourselves
                {
                    Subject = subject,
                    Body = body
                })

                    smtp.Send(message);
                EmailViewModel blank_model = new EmailViewModel { };
                return View(blank_model);
            }

            else
                return View(model);
        }
    }
}

