using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification()
        {
            AddInclude(x => x.Type);
            AddInclude(x => x.Brand);
        }
    }
}
