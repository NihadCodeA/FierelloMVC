using Microsoft.EntityFrameworkCore;

namespace Fierello.Models
{
    public class FierrelloDB : DbContext
    {
        public FierrelloDB(DbContextOptions<FierrelloDB> options) : base(options) { }

        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SliderImages> SliderImages { get; set; }
    }
}
