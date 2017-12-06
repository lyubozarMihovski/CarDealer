namespace CarDealer.Services.Models
{
    using System;

    public class CustomerAddModel
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
