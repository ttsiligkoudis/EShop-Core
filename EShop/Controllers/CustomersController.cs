using System;
using System.Threading.Tasks;
using EShop.Helpers;
using Microsoft.AspNetCore.Mvc;
using ISession = EShop.Helpers.ISession;
using DataModels.Dtos;
using AutoMapper;

namespace EShop.Controllers
{
    public class CustomersController : BaseController
    {
        public CustomersController(IUserAccess userAccess, ISession session, IMapper mapper) : base(userAccess, session, mapper)
        {
        }

        public async Task<IActionResult> Index()
        {
            var customer = _session.GetCustomer();
            if (!_userAccess.IsAdmin(customer))
            {
                throw new AccessViolationException();
            }
            var customers = await _client.CustomerClient.GetListAsync("Customers");
            return View(customers);
        }

        public IActionResult Create()
        {
            var customer = new CustomerDto()
            {
                RegDate = DateTime.Now
            };
            return View("CustomerForm", customer);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _client.CustomerClient.GetAsync("Customers/" + id);
            if (customer == null)
            {
                throw new NullReferenceException();
            }
            return View("CustomerForm", customer);
        }

        [HttpPost]
        public async Task<IActionResult> Save(CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return View("CustomerForm", customer);
            }
            if (customer.Id == 0)
            {
                await _client.CustomerClient.PostAsync(customer, "Customers");
            }
            else
            {
                await _client.CustomerClient.PutAsync(customer, "Customers/" + customer.Id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _client.CustomerClient.GetAsync("Customers/" + id);
            if (customer == null)
            {
                throw new NullReferenceException();
            }
            var loggedCustomer = _session.GetCustomer();
            if (loggedCustomer?.Id == customer.Id)
            {
                await _client.CustomerClient.DeleteAsync(id, "Customers/" + id);
                return RedirectToAction("Logout", "Users", customer.UserId);
            }
            await _client.CustomerClient.DeleteAsync(id, "Customers/" + id);
            return RedirectToAction("Index");
        }

    }
}