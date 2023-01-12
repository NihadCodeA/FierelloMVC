using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fierello.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [StringLength(maximumLength:30)]
        public string FirstTitle { get; set; }
        [StringLength(maximumLength:30)]
        public string SecondTitle { get; set; }
        [StringLength(maximumLength:150)]
        public string Description { get; set; }

        public List<SliderImages>? SliderImages { get; set; }
        [NotMapped]
        public List<int>? SliderImageIds { get; set; }
        [NotMapped]
        public List<IFormFile>? SliderImageFiles { get; set; }
    }
}
