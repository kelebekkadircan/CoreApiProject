﻿using HotelProject.WebUI.Models.AdminMail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelProject.WebUI.Controllers
{
    public class AdminMailController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(AdminMailViewModel adminMailViewModel)
        {
            MimeMessage mimeMessage =  new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("APARTSANDMATES ADMİN","kelebekkadircan@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo= new MailboxAddress("APARTSANDMATES USER",adminMailViewModel.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodybuilder = new BodyBuilder();

            bodybuilder.TextBody = adminMailViewModel.Body;
            mimeMessage.Body = bodybuilder.ToMessageBody();

            mimeMessage.Subject = adminMailViewModel.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            //password key olarak değiştir
            client.Authenticate("kelebekkadircan@gmail.com", "jsgaboaroylrdbwj");
            client.Send(mimeMessage);
            client.Disconnect(true);




            return RedirectToAction("Index" , "AdminContact");
        }


    }
}