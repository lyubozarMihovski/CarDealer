namespace CarDealer.Services.Models
{
    using System;

    public class SalesModel
    {
        public int Id { get; set; }

        public CarModel Car { get; set; }

        public string CustomerName { get; set; }

        public decimal Price { get; set; }

        public double Discount { get; set; }
    }
}
