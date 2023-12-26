using System.Linq.Expressions;
using BuildingBlock.Core.Domain.Specifications.Abstractions;
using ShoppingManagement.Core.Domain.ProductAggregate.Entities;

namespace ShoppingManagement.Core.Domain.ProductAggregate.Specifications;

public class ProductCodePartialMatchSpecification : Specification<Product>
{
    private readonly string _code;

    public ProductCodePartialMatchSpecification(string code)
    {
        _code = code;
    }

    public override Expression<Func<Product, bool>> ToExpression()
    {
        // if (string.IsNullOrWhiteSpace(_code)) return product => true;
        //
        // return product => product.Code.ToUpper().Contains(_code.ToUpper());
        throw new NotImplementedException();
    }
}