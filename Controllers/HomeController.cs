using Microsoft.AspNetCore.Mvc;
using PersonalSiteMVC.Models;
using System.Diagnostics;
using Microsoft.Extensions.Options;
using MimeKit; //Added for access to MimeMessage class
using MailKit.Net.Smtp; //Added for access to SmtpClient class

namespace PersonalSiteMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CredentialSettings _credentials;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IOptions<CredentialSettings> settings, IConfiguration config)
        {
            _logger = logger;
            _credentials = settings.Value;
            _config = config;
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            string message = $"You have recieved a new email from your site's contact form!<br />" +
                $"Sender: {cvm.Name}<br />Email: {cvm.Email}<br />Subject: {cvm.Subject}<br />" +
                $"Message: {cvm.Message}";

            var mm = new MimeMessage();

            mm.From.Add(new MailboxAddress("Sender", _credentials.Email.Username));

            mm.To.Add(new MailboxAddress("Personal", _credentials.Email.Recipient));

            mm.Subject = $"New contact form message: [{cvm.Subject}]";

            mm.Body = new TextPart("HTML") { Text = message };

            mm.Priority = MessagePriority.Urgent;

            mm.ReplyTo.Add(new MailboxAddress("User", cvm.Email));

            using (var client = new SmtpClient())
            {
                client.Connect(_credentials.Email.Server, 8889);

                client.Authenticate(_credentials.Email.Username, _credentials.Email.Password);

                try
                {
                    client.Send(mm);
                }
                catch (Exception ex)
                {
                    ViewBag.ErrorMessage = $"There was an error in processing your request. " +
                        $"Please try again later.<br />Error Message: {ex.StackTrace}";

                    return View(cvm);
                }
            }

            return View("EmailConfirmation", cvm);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View();
        }

        public IActionResult Resume()
        {
            return View();
        }

        public IActionResult Classmates()
        {
            return View();
        }

        public IActionResult PortfolioDetails()
        {
            return View();
        }

        public IActionResult ToDoDetails()
        {
            return View();
        }

        public IActionResult StorefrontDetails()
        {
            return View();
        }

        public IActionResult ToDoAPIDetails()
        {
            return View();
        }

        public IActionResult TeamDetails()
        {
            return View();
        }
    }

}

