namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;

    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult Local()
        {
            return View("Suppliers", this.GetSupplierModel(false));
        }

        public IActionResult Importers()
        {
            return View("Suppliers", this.GetSupplierModel(true));
        }

        private SuppliersModel GetSupplierModel(bool importers)
        {
            var type = importers ? "Importer" : "Local";

            var suppliers = this.suppliers.All(importers);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}
