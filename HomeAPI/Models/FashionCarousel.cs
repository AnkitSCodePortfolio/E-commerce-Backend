using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAPI.Models
{
    public class FashionCarousel
    {
        public double Id { get; set; }
        public string Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }

        public string? FilePath { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }
    }
}
