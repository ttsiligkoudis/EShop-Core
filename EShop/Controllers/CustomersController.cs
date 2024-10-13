using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Client;
using System.Collections.Generic;
using FilesClient;

namespace EShop.Controllers
{
    public class CustomersController : BaseController
    {
        public CustomersController(
            IHttpContextAccessor accessor, 
            IConfiguration configuration, 
            IClient client,
            FilesClientHandler filesClient) : base(accessor, configuration, client, filesClient)
        {
        }

        public async Task<IActionResult> Index()
        {
            if (!IsAdmin)
            {
                throw new AccessViolationException();
            }
            var customers = await _client.GetAsync<List<CustomerDto>>("Customers");
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
            var customer = await _client.GetAsync<CustomerDto>("Customers/" + id);
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
                await _client.PostAsync(customer, "Customers");
            }
            else
            {
                await _client.PutAsync(customer, "Customers/" + customer.Id);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _client.GetAsync<CustomerDto>("Customers/" + id) ?? throw new NullReferenceException();

            var loggedCustomer = Customer;
            await _client.DeleteAsync($"Customers/{id}");

            if (loggedCustomer?.Id == customer.Id) return RedirectToAction("Logout", "Users", customer.UserId);

            return RedirectToAction("Index");
        }
    }
}