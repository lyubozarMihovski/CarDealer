namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Customers;
    using CarDealer.Services;
    using CarDealer.Services.Models;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customers)
        {
            this.customers = customers;
        }

        [Route("customers/edit/{customerId}")]
        public IActionResult Edit(int customerId)
        {
            var customer = this.customers.ById(customerId);

            if (customer == null)
            {
                return NotFound();
            }

            return View(new OrderedCustomerModel
            {
                Name = customer.Name,
                BirthDate = customer.BirthDate,
                IsYoungDriver = customer.IsYoungDriver
            });
        }

      [HttpPost]
      [Route("customers/edit/{customerId}")]
      public IActionResult Edit(int customerId, CustomerAddModel model)
      {
            if (!ModelState.IsValid)
            {
                return null;
            }

            bool customerExists = this.customers.Exists(customerId);

            if (!customerExists)
            {
                return NotFound();
            }

            this.customers.Edit(customerId, model.Name, model.BirthDate, model.IsYoungDriver);
            return RedirectToAction(nameof(All));
      }

        [Route(nameof(Create))]
        public IActionResult Create()
        {
            return this.View();
        }

        [Route(nameof(Create))]
        [HttpPost]
        public IActionResult Create(CustomerAddModel model)
        {
            if (!ModelState.IsValid)
            {
                return null;
            }
            string name = model.Name;
            DateTime birthDate = model.BirthDate;
            bool isYoungDriver = model.IsYoungDriver;

            this.customers.Add(name, birthDate, isYoungDriver);

            return RedirectToAction(nameof(All));
        }

        [Route("customers/{id}")]
        public IActionResult CustomerById(int id)
        {
            return this.View(customers.CustomerById(id));
        }
        [Route("customers")]
        [Route("customers/all/{order}")]
        [Route("customers/all")]
        public IActionResult All(string order)
        {
            if (string.IsNullOrEmpty(order))
            {
                order = "ascending";
            }
            var orderDirection = order.ToLower() == "descending"
                ? OrderType.Descending
                : OrderType.Ascending;

            var customersAll = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = customersAll,
                OrderDirection = orderDirection
            });
        }
    }
}
