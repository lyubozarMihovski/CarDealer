using System.Collections.Generic;
using CarDealer.Services.Models;
using CarDealer.Data;
using System.Linq;
using CarDealer.Domain;

namespace CarDealer.Services.Implementations
{
    public class PartService : IPartService
    {
        private readonly CarDealerDbContext db;

        public PartService(CarDealerDbContext db)
        {
            this.db = db;
        }
        public IEnumerable<PartListingModel> All(int page = 1, int pageSize = 10)
        {
           return this.db.Parts.OrderByDescending(p => p.Id).Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(p => new PartListingModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Quantity = p.Quantity,
                    Price = p.Price,
                    SupplierName = p.Supplier.Name
                })
                .ToList();
        }

        public IEnumerable<PartSelectModel> AllSelected()
        {
            return this.db.Parts
                .OrderBy(p => p.Id)
                .Select(p => new PartSelectModel
                {
                    Id = p.Id,
                    Name = p.Name
                })
                .ToList();
        }

        public PartDetailsModel ById(int id)
        {
            return this.db.Parts.Where(p => p.Id == id)
                .Select(p => new PartDetailsModel
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity
                })
                .FirstOrDefault();
        }

        public void Create(string name, decimal price, int quantity, int supplierId)
        {
            var part = new Part
            {
                Name = name,
                Price = price,
                Quantity = quantity > 0 ? quantity : 1,
                SupplierId = supplierId
            };

            this.db.Parts.Add(part);
            this.db.SaveChanges();
        }

        public void Delete(int id)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            this.db.Parts.Remove(part);
            this.db.SaveChanges();
        }

        public void Edit(int id, decimal price, int quantity)
        {
            var part = this.db.Parts.Find(id);

            if (part == null)
            {
                return;
            }

            part.Price = price;
            part.Quantity = quantity;

            this.db.SaveChanges();
        }

        public int Total()
        {
            return this.db.Parts.Count();
        }
    }
}
