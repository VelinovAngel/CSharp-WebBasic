namespace Andrey.Data.Models
{
    using Andrey.Data.Enum;
    using System.ComponentModel.DataAnnotations;


    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(10)]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Category Category { get; set; }

        [Required]
        public Gender Gender { get; set; }
    }
}
