using System.Linq.Expressions;
using Core.Entities;

namespace Core.Specifications
{
    public class ProductsWithTypesAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification()
        {
            AddInclude(b => b.ProductBrand);
            AddInclude(t => t.ProductType);
        }

        public ProductsWithTypesAndBrandsSpecification(int id) :
            base(x => x.Id == id)
        {            
            AddInclude(b => b.ProductBrand);
            AddInclude(t => t.ProductType);
        }
    }
}