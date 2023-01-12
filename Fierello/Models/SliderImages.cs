using System.ComponentModel.DataAnnotations.Schema;

namespace Fierello.Models
{
    public class SliderImages
    {
        public int Id { get; set; }
        public int SliderId { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile? ImgFile { get; set; }
        public Slider? Slider { get; set; }
    }
}
