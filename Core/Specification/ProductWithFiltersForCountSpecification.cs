using Core.Entities;

namespace Core.Specification
{
    public class ProductWithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductWithFiltersForCountSpecification(ProductSpecParams productParams) : base(x => (string.IsNullOrEmpty(productParams.Search) || x.Title.ToLower().Contains(productParams.Search)) && (!productParams.BrandId.HasValue || x.BrandId == productParams.BrandId) && (!productParams.TypeId.HasValue || x.TypeId == productParams.TypeId))
        {
            
        }
    }
}
