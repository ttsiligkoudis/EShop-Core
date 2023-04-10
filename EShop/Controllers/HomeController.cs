using AutoMapper;
using Client;
using DataModels.Dtos;
using EShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ViewModels;

namespace EShop.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUserAccess userAccess, ISession session, IMapper mapper) : base(userAccess, session, mapper)
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
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public async Task<IActionResult> GetCalendar()
        {
            try
            {
                IEnumerable<OrderDto> orders;
                var customer = _session.GetCustomer();

                if (!_userAccess.IsCustomer(customer))
                    return RedirectToAction("Index");
                else if (!_userAccess.IsAdmin(customer))
                    orders = await _client.OrderClient.GetListAsync("Orders/Customer/" + customer.Id);
                else
                    orders = await _client.OrderClient.GetListAsync("Orders");

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