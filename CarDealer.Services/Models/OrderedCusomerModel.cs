﻿namespace CarDealer.Services.Models
{
    using System;

    public class OrderedCustomerModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
