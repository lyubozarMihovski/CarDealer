namespace CarDealer.App.Models.Cars
{
    using CarDealer.Services.Models;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CarFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        [Display(Name = "Travelled Distance")]
        [Range(0, long.MaxValue , ErrorMessage = "{2} must be positive number.")]
        public long TravelledDistance { get; set; }

        public IEnumerable<int> SelectedParts { get; set; }

        [Display(Name = "Parts")]
        public IEnumerable<SelectListItem> Parts { get; set; }

    }
}
