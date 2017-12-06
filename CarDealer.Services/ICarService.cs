﻿namespace CarDealer.Services
{
    using CarDealer.Services.Models;
    using System.Collections.Generic;
    
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> WithParts();

        void Create(string make, string model, long travelledDistance, IEnumerable<int> parts);
    }
}
