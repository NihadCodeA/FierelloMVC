using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fierello.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        [StringLength(maximumLength: 25)]
        public string Name { get; set; }
        public double Price { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
        public Category? Category { get; set; }
    }
}
