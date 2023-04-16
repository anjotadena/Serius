using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        public string PictureUrl { get; set; }

        public Type Type { get; set; }

        public int TypeId { get; set; }

        public Brand Brand { get; set; }

        public int BrandId { get; set; }
    }
}
