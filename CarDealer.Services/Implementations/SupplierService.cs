namespace CarDealer.Services.Implementations
{
    using System.Collections.Generic;
    using CarDealer.Services.Models;
    using CarDealer.Data;
    using System.Linq;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All(bool isImporter)
        {
            return this.db.Suppliers.OrderByDescending(s => s.Id)
                .Where(s => s.IsImporter == isImporter)
                .Select(s => new SupplierModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    TotalParts = s.Parts.Count
                }
                ).ToList();
        }

        public IEnumerable<SupplierIdModel> AllSuppliers()
        {
            return this.db
                .Suppliers
                .OrderBy(s => s.Name)
                .Select(s => new SupplierIdModel
                {
                    Id = s.Id,
                    Name = s.Name
                })
                .ToList();
        }
    }
}
