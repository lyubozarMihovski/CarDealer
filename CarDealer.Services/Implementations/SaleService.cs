namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;

    public class SaleService : ISaleService
    {
        private readonly CarDealerDbContext db;

        public SaleService(CarDealerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<SalesModel> All()
        {
            return this.db.Sales.OrderByDescending(s => s.Id)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Select(p => p.Part.Price).Sum(),
                    Discount = s.Discount

                }).ToList();
        }
        public IEnumerable<SalesModel> Discounted()
        {
            return this.db.Sales.Where(s => s.Discount != 0)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Select(p => p.Part.Price).Sum(),
                    Discount = s.Discount

                }).ToList();
        }
        public IEnumerable<SalesModel> DiscountedByPercent(double percent)
        {
            return this.db.Sales.Where(s => s.Discount == percent / 100)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Select(p => p.Part.Price).Sum(),
                    Discount = s.Discount

                }).ToList();
        }

        public SalesModel SaleById(int id)
        {
            
            return this.db.Sales.Where(s => s.Id == id)
                .Select(s => new SalesModel
                {
                    Car = new CarModel
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Price = s.Car.Parts.Select(p => p.Part.Price).Sum(),
                    Discount = s.Discount
                }).FirstOrDefault();
        }
    }
}
