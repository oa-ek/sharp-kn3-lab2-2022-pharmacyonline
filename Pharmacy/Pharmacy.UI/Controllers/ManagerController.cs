using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Packaging;
using Pharmacy.Core;
using Pharmacy.Repos;
using System.Collections;
using System.Diagnostics.Metrics;
using System.Net;
using System.Net.Mail;

namespace Pharmacy.UI.Controllers
{
    public class ManagerController : Controller
    {
        private readonly OrderRepository _orderRepository;
        private readonly Service service;

        public ManagerController(OrderRepository orderRepository, Service service)
        {
            _orderRepository = orderRepository;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View("Orders", await _orderRepository.GetAllOrder());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string Orderid)
        {

            var order = await _orderRepository.GetOrder(Orderid);
            string emailTo = order.details.Address.Email;
            var count = 0;

            var items = new List<string>();
            /*foreach (var i in order.details.orderItems)
            {
                count++;
                items.Add($"{count} |{i.medicaments}  | {i.Quantity}  | {i.Price}");
            }*/
            var body = "<p>Email From: {0}</p><p>Message:</p><p>{1}</p>" +
                "<table class=\"table table-border\">\r\n<thead>\r\n<tr>\r\n<th>#</th>\r\n<th>Назва</th>\r\n<th>К-сть</th>\r\n<th>Ціна</th>\r\n</thead>\r\n</tr>";               
            foreach (var i in order.details.orderItems)
            {
                count++;
                body += $"<br/>\r\n<tbody>\r\n<tr>\r\n<td>\t\t   {count}</td>\r\n<td>{i.medicaments.Name}</td>\r\n<td>\t   {i.Quantity}</td>\r\n<td>{i.Price}</td>\r\n</tr>";
                //items.Add($"{count} |{i.medicaments}  | {i.Quantity}  | {i.Price}");
            }
            body += $"<tr>\r\n<td><strong>Доставка: </strong><p>{order.details.TypeOfDelivery}</p></td>\r\n</tr>\r\n" +
                $"<br/>\r\n<tr>\r\n<td><strong>Загальна сума: {order.Total} грн</strong></td>\r\n</tr>\r\n</tbody>\r\n</table>";

            var message = new MailMessage();
                message.To.Add(new MailAddress(emailTo));  // replace with valid value 
                message.From = new MailAddress("user2002anhelina@gmail.com");  // replace with valid value
                message.Subject = "Ваше замовлення Pharmacy підтверджено!";
            
            message.Body = string.Format(body, "Pharmacy", message.Subject);
                    
                message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "user2002anhelina@gmail.com",  // replace with valid value
                    Password = "uckpecepghjjvvny"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(message);
                return RedirectToAction("Index"); }

            }
        
            /*
            [HttpPost]
            public ViewResult Email()
            {
                    MailMessage mail = new MailMessage();
                    mail.To.Add("user2002anhelina@gmail.com");
                    mail.From = new MailAddress("user2002anhelina@gmail.com", "Pharmacy");
                    mail.Subject = "Сообщение от System.Net.Mail";
                    string Body = "<div style=\"color: red;\">Сообщение от System.Net.Mail</div>";
                    mail.Body = Body;
                    mail.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("user2002anhelina@gmail.com", "20122022"); // Enter seders User name and password       
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                    return View();
            }*/

            [HttpPost]
        public async Task<IActionResult> Index(string customerName)
        {
            if(customerName == null)
                return View("Orders", await _orderRepository.GetAllOrder());
            else
            return View("Orders", await _orderRepository.GetSearchAllOrder(customerName));
        }

            // EDIT

            [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var statuslist = new List<string>
            {
                "NEW",
                "підтверджено",
                "відправлено",
            };
            var order = await _orderRepository.GetOrder(id);
            ViewBag.Status = statuslist;
            ViewData["selectstatus"] = order.Status.ToString();
            return View(await _orderRepository.GetOrder(id));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(string modelId, string status, bool ispaid)
        {
                await _orderRepository.UpdateAsync(modelId, status, ispaid);
                return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(string id)
        {
            var order = await _orderRepository.GetOrder(id);
            var detid = order.details;
            ViewBag.Order = order;
            var items = await _orderRepository.GetOrderItems(detid.Id);
            ViewBag.Items = items;
            return View(detid);
        }

        public async Task<IActionResult> SuccessfulOrder(Order order)
        {

            var details = order.details;
            ViewBag.Order = order;
            var items = await _orderRepository.GetOrderItems(details.Id);
            ViewBag.Items = items;
            return View("SuccessfulOrder",details.Id);
        }
    }}

