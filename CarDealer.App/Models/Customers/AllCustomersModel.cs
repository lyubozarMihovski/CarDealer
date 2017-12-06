namespace CarDealer.App.Models.Customers
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public class AllCustomersModel
    {

        public IEnumerable<OrderedCustomerModel> Customers { get; set; }

        public OrderType OrderDirection { get; set; }
    }
}
