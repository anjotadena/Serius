using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DiscountPercentage { get; set; }

        public decimal Rating { get; set; }

        public string Thumbnail { get; set; }

        public ICollection<Image> Images { get; set; }

        public int Stock { get; set; }

        public Type Type { get; set; }

        public int TypeId { get; set; }

        public Brand Brand { get; set; }

        public int BrandId { get; set; }
    }
}
