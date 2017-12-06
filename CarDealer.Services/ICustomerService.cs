namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System;
    using System.Collections.Generic;

    public interface ICustomerService
    {
        IEnumerable<OrderedCustomerModel> OrderedCustomers(OrderType order);

        CustomerModel CustomerById(int id);

        void Add(string name, DateTime birthDate, bool isyoungDriver);

        OrderedCustomerModel ById(int id);

        void Edit(int id, string name, DateTime birthDate, bool isYoungDriver);

        bool Exists(int id);
    }
}