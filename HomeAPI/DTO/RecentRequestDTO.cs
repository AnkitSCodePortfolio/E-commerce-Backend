namespace HomeAPI.DTO
{
    public class RecentRequestDTO
    {
        public string Name { get; set; }
        public string? Price { get; set; }
        public string? Description { get; set; }
        public IFormFile? Image { get; set; }

    }
}
