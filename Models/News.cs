namespace Project3API.Models
{
    public class News
    {
        public int newsId { get; set; }
        public string? title { get; set; }
        public string? content { get; set; }
        public string? shortContent { get; set; }
        public string? personId { get; set; }
        public string? type { get; set; }
        public string? imageUrl { get; set; }
        public IFormFile? getImageUrl { get; set; }
        public DateTime createdAt { get; set; }
        
    }
}
