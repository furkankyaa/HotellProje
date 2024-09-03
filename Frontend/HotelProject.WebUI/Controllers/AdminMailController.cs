using HotelProject.WebUI.Models.Mail;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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
        public IActionResult  Index(AdminMailViewModel model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressfrom = new MailboxAddress("HotelierAdmin", "furkannkayaa90@gmail.com");       //kimden olacağı
            mimeMessage.From.Add(mailboxAddressfrom); 

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",model.ReceiverMail);          //burası kime olacağı
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder= new BodyBuilder();
            bodyBuilder.TextBody = model.Body;                           //mesajın içeriği
            mimeMessage.Body=bodyBuilder.ToMessageBody();

            mimeMessage.Subject=model.Subject;    //mesaj baslıgı

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587,false);
            client.Authenticate("furkannkayaa90@gmail.com", "inyqsvxgrcmyijck");
            client.Send(mimeMessage);
            client.Disconnect(true);

            //gönderilen mailin veri tabanına kaydedilmesi 


            return View();
        }
    }
}
 