namespace CarDealer.Domain
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Car
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Make { get; set; }

        [Required]
        [MaxLength(100)]
        public string Model { get; set; }

        public List<Sale> Sales { get; set; } = new List<Sale>();

        [Range(0, long.MaxValue)]
        public long TravelledDistance { get; set; }

        public ICollection<PartCar> Parts { get; set; } = new List<PartCar>();
    }
}
