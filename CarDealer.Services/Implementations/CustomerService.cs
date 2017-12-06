namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;
    using CarDealer.Domain;

    public class CustomerService : ICustomerService
    {
        private readonly CarDealerDbContext db;

        public CustomerService(CarDealerDbContext db)
        {
            this.db = db;
        }
        
        public void Add(string name, DateTime birthDate, bool isYoungDriver)
        {
            var customer = new Customer
            {
                Name = name,
                BirthDate = birthDate,
                IsYoungDriver = isYoungDriver
            };
            db.Customers.Add(customer);
            db.SaveChanges();
        }

        public OrderedCustomerModel ById(int id)
        {
            return this.db.Customers.Where(c => c.Id == id)
                .Select(c => new OrderedCustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver
                })
                .FirstOrDefault();
        }

        public CustomerModel CustomerById(int id)
        {
            return this.db.Customers.Where(c => c.Id == id)
                .Select(c => new CustomerModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    TotalCars = c.Sales.Count(),
                    TotalSpentMoney = (decimal)c.Sales.Select(s => s.Car.Parts.Select(p => p.Part.Price).Sum()).Sum()
                }).FirstOrDefault();
        }

        public void Edit(int id, string name, DateTime birthDate, bool isYoungDriver)
        {
            var existingCustomer = this.db.Customers.Find(id);
            if (existingCustomer == null)
            {
                return;
            }

            existingCustomer.Name = name;
            existingCustomer.BirthDate = birthDate;
            existingCustomer.IsYoungDriver = isYoungDriver;

            this.db.SaveChanges();
        }

        public bool Exists(int id)
        {
            return this.db.Customers.Any(c => c.Id == id);
        }

        public IEnumerable<OrderedCustomerModel> OrderedCustomers(OrderType order)
        {
            var customersQuery = this.db.Customers.AsQueryable();

            switch (order)
            {
                case OrderType.Ascending:
                    customersQuery = customersQuery.OrderBy(c => c.BirthDate).ThenBy(c => c.Name);
                    break;
                case OrderType.Descending:
                    customersQuery = customersQuery.OrderByDescending(c => c.BirthDate).ThenBy(c => c.Name);
                    break;
                default:
                    throw new InvalidOperationException($"Invalid order direction: {order}");
            }

            return customersQuery.Select(c => new OrderedCustomerModel
            {
                Id = c.Id,
                Name = c.Name,
                BirthDate = c.BirthDate,
                IsYoungDriver = c.IsYoungDriver
            })
            .ToList();
        }
    }
}
