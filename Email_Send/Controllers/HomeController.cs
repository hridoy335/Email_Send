using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Email_Send.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Email()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Email( string FromMail, string Subject, string Discription)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   var sendmail = new MailAddress("roy.hridoy277@gmail.com", "Hridoy Roy");
                    var receiver = new MailAddress(FromMail, "Receiver");
                    var password = "Suvo@@$$%%";
                    var subject = Subject;
                    var body = Discription;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(sendmail.Address,password)
                        
                    };

                    using (var mes = new MailMessage(sendmail, receiver)
                    {
                        Subject=subject,
                        Body=body
                    }
                    )
                    {
                        smtp.Send(mes);
                    }

                }

                return View("Index");
            }

            catch (Exception ex)
            {
                ViewBag.error = ex.ToString();
            }
            return View();
        }
    }
}