using System;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;
using Org.BouncyCastle.Ocsp;
using Shop.Core.Dto.EmailDtos;
using Shop.Core.ServiceInterface;

namespace Shop.ApplicationServices.Services
{
    public class EmailServices : IEmailServices
    {

        private readonly IConfiguration _config;

        public EmailServices(IConfiguration config)
        {
            _config = config;
	    }

        public void SendEmail(EmailDto request)
        {
            var email = new MimeMessage();

            var host_ = _config.GetSection("EmailHost").Value;
            var username_ = _config.GetSection("EmailUsername").Value;
            var password_ = _config.GetSection("EmailPassword").Value;

            email.From.Add(MailboxAddress.Parse(username_));
            email.To.Add(MailboxAddress.Parse(request.To));

            email.Subject = request.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = request.Body
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(host_, 587, SecureSocketOptions.StartTls);

                
                smtp.Authenticate(username_, password_);

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }
    }
}

