using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAPI.DTO
{
    public class ApplianceUpdateDTO
    {
        public string Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
