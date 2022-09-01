using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams productParams)
            : base(x =>
            (string.IsNullOrEmpty(productParams.Search) || (x.Name.ToLower().Contains(productParams.Search))) &&
            (!productParams.BrandId.HasValue || x.ProductBrandId == productParams.BrandId) &&
            (!productParams.TypeId.HasValue || x.ProductTypeId == productParams.TypeId))
        {
            AddInclude(b => b.ProductBrand);
            AddInclude(t => t.ProductType);
            AddOrderBy(o => o.Name);
            ApplyPaging(productParams.PageSize, productParams.PageSize * (productParams.PageIndex - 1));

            //check query that comes from http request.
            if (!string.IsNullOrEmpty(productParams.Sort))
            {
                switch (productParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(o => o.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(o => o.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }

        public ProductsWithTypesAndBrandsSpecification(int id) :
            base(x => x.Id == id)
        {            
            AddInclude(b => b.ProductBrand);
            AddInclude(t => t.ProductType);
        }
    }
}