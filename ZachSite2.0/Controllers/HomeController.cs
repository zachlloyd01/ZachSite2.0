using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ZachSite2._0.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() //Initial Home Page (Index.cshtml)
        {
            ViewBag.newRequest = TempData["newRequest"];
            TempData["newRequest"] = string.Empty;
            return View(); //return the page with no data
        }

        public ActionResult About() //About Me Page (About.cshtml)
        {
            return View(); //return the page with no data
        }

        public ActionResult Contact() //Contact me Page (Contact.cshtml)
        { 

            return View(); //return the page with no data
        }

        [HttpPost] //Form Post
        [ValidateAntiForgeryToken] //No forgery here 
        public ActionResult ContactForm(Models.Contact contact) //The Controller for the form object
        {
            if (contact.Name == null) //If there is no name inputted
            {
                ViewBag.contacterror = "Name"; //Give error
                return View("Contact"); //Put error on the page
            }

            else if (contact.Email == null) //If there is no email inputted
            {
                ViewBag.contacterror = "Email"; //Give error
                return View("Contact"); //Put error on the page
            }

            else if (contact.Message == null)
            {
                ViewBag.contacterror = "Message";
                return View("Contact");
            }

            ViewBag.contacterror = string.Empty;
            string Name = contact.Name;
            string Email = contact.Email;
            string Message = contact.Message;

            string time = DateTime.Now.ToString("hh:mm tt");

            var returnMessage = new MailMessage();
            returnMessage.To.Add(new MailAddress(Email));
            returnMessage.From = new MailAddress("zachlloyd01@gmail.com");
            returnMessage.Subject = "Your recent contact submission to Zach";
            returnMessage.Body = $"{Name}, \nAt {time}, you submitted a Contact request on Zach Lloyd's website. Your message was as follows: \n{Message}\nThanks, \nZach";

            var sendMessage = new MailMessage();
            sendMessage.To.Add("zachlloyd01@gmail.com");
            sendMessage.From = new MailAddress("zachlloyd01@gmail.com");
            sendMessage.Subject = $"New message on site from {Name}";
            sendMessage.Body = $"Email is: {Email}\nMessage is:\n{Message}";

            using(var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "zachlloyd01@gmail.com",
                    Password = "***********", //THIS IS NOT THE PASSWORD - SHOULD BE CHANGED BEFORE EVERY COMMIT TO NOT GIVE OUT MY EMAIL :)
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Send(returnMessage);
                smtp.Send(sendMessage);
            }

            ViewBag.contactSuccess = "true";
            return View("Index");

        }
    }
}