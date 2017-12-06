namespace CarDealer.App.Controllers
{
    using CarDealer.App.Models.Cars;
    using CarDealer.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CarsController : Controller
    {
        private readonly ICarService cars;
        private readonly IPartService parts;

        public CarsController(ICarService cars, IPartService parts)
        {
            this.cars = cars;
            this.parts = parts;
        }

        [Route("cars/create", Order = 2)]
        public IActionResult Create()
        {

            return View(new CarFormModel
            {
                Parts = this.GetPartsSelectItem()
            });
        }

        [HttpPost]
        [Route("cars/create", Order = 2)]
        public IActionResult Create(CarFormModel carModel)
        {
            if (!ModelState.IsValid)
            {
                carModel.Parts = this.GetPartsSelectItem();
                return View(carModel);
            }

            this.cars.Create(carModel.Make, carModel.Model, carModel.TravelledDistance, carModel.SelectedParts);

            return RedirectToAction(nameof(Parts));
        }

        [Route("cars/{make}", Order = 3)]
        public IActionResult ByMake(string make)
        {
            var cars = this.cars.ByMake(make);

            return View(new CarsByMakeModel
            {
                Make = make,
                Cars = cars
            });
        }
        [Route("cars/parts", Order = 1)]
        public IActionResult Parts()
            => View(this.cars.WithParts());

        private IEnumerable<SelectListItem> GetPartsSelectItem()
        {
            return this.parts
                .AllSelected()
                .Select(p => new SelectListItem
                {
                    Text = p.Name,
                    Value = p.Id.ToString()
                });
                
        }
    }
}
