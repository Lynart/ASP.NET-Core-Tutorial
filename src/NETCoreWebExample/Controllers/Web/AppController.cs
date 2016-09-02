using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NETCoreWebExample.Services;
using NETCoreWebExample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETCoreWebExample.Controllers.Web
{
    public class AppController : Controller
    {
        private IMailService _mailService;
        private IConfigurationRoot _config;

        public AppController(IMailService mailService, IConfigurationRoot config)
        {
            _mailService = mailService;
            _config = config;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel model)
        {
            if (model.Email.Contains("aol.com"))
            {
                //Empty first option will cause the whole object to be false
                ModelState.AddModelError("Email", "We don't support AOL addresses");
            }
            if (ModelState.IsValid)
            {
                _mailService.SendMail(_config["MailSettings:ToAddress"], model.Email, "From Me", model.Message);
                //Clears model
                ModelState.Clear();
                ViewBag.UserMessage = "Message sent";
            }
            return View();
        }

        public IActionResult About()
        {
            return View();
        }
    }
}
