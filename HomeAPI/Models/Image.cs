using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAPI.Models
{
    public class Image
    {
        public int Id { get; set; }
        [NotMapped]
        public IFormFile? File { get; set; }
        public string FileExtension { get; set; }
        public string FilePath { get; set; }

    }
}
                        