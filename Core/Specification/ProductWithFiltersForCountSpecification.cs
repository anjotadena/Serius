using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x => (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) && (!productParams.TypeId.HasValue || x.TypeId == productParams.TypeId))
        {
            
        }
    }
}
