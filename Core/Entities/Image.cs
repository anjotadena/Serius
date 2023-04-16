namespace Core.Entities
{
    public class Image : BaseEntity
    {
        public string FileName { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
    }
}
