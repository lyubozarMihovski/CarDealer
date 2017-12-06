﻿namespace CarDealer.App.Models.Cars
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;

    public class CarsByMakeModel
    {
        public string Make { get; set; }

        public IEnumerable<CarModel> Cars { get; set; }
    }
}
