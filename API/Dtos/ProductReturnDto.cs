using Core.Entities;

namespace API.Dtos
{
    public class ProductReturnDto
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal Rating { get; set; }

        public string? Thumbnail { get; set; }

        public ICollection<string>? Images { get; set; }

        public int Stock { get; set; }

        public string Type { get; set; }

        public string Brand { get; set; }
    }
}
