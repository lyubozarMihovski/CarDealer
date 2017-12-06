namespace CarDealer.Services.Models
{
    using System;

    public class CustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TotalCars { get; set; }

        public decimal TotalSpentMoney { get; set; }
    }
}
