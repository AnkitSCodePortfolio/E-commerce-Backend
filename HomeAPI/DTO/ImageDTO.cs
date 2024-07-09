using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAPI.DTO
{
    public class ImageDTO
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }
    }
}
