using Core.Entities;
using System.Linq.Expressions;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandSpecification(string sort)
        {
            AddInclude(x => x.Type);
            AddInclude(x => x.Brand);
            AddOrderBy(x => x.Title);

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Title);
                        break;
                }
            }    
        }

        public ProductsWithTypesAndBrandSpecification(int id) : base(x => x.Id == id)
        {
            AddInclude(x => x.Type);
            AddInclude(x => x.Brand);
        }
    }
}
