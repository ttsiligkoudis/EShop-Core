using DataModels.Dtos;
using Google.Apis.Http;
using Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;

namespace EShop.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IHttpContextAccessor accessor) : base(accessor)
        {
        }

        public async Task<ActionResult> Index()
        {
            var products = (await _client.ProductClient.GetListAsync("Products/Random/?length=3")).ToList();
            
            return View(products);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public async Task<ActionResult> ContactMessage(string name, string email, string message)
        {
            var msg = new MessageDto
            {
                Email = email,
                Subject = "Contact Form Submission",
                Body = EmailHelper.ContactMessageHtml(name, email, message)
            };

            await _client.MessagesClient.PostAsync(msg, $"Messages/SendMessage");

            return new JsonResult("We have successfully received your message and our team will get back to you as soon as possible.");
        }

        public async Task<IActionResult> GetCalendar()
        {
            try
            {
                IEnumerable<OrderDto> orders;

                if (IsAdmin)
                    orders = await _client.OrderClient.GetListAsync("Orders");
                else if (IsCustomer)
                    orders = await _client.OrderClient.GetListAsync("Orders/Customer/" + Customer.Id);
                else
                    return RedirectToAction("Index");

                if (orders == null)
                    return RedirectToAction("Index");

                var calendarEvents = orders.Select(item => new CalendarViewModel
                {
                    id = item.Id,
                    start = item.OrderDate.ToString("s"),
                    title = item.CustomerName,
                    body = item.FinalPrice.ToString(),
                    allDay = false
                }).ToList();
                return new JsonResult(calendarEvents);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}