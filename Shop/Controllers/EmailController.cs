using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using Shop.Core.Dto.EmailDtos;
using Shop.Core.ServiceInterface;
using Shop.Models.Email;

namespace Shop.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailServices _emailServices;
        public EmailController(IEmailServices emailServices)
        {
            _emailServices = emailServices;
	    }

        public IActionResult Index()
        {
            return View();
	    }

        [HttpPost]
        public IActionResult SendEmail(EmailViewModel model)
	    {
            if (ModelState.IsValid)
            {
                EmailDto dto = new EmailDto()
                {
                    To = model.To,
                    Subject = model.Subject,
                    Body = model.Body
                };

                _emailServices.SendEmail(dto);
                return View(model);
            }

            return View(nameof(Index));
        } 
    }
}

