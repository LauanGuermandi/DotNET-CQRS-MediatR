using Products.Api.Domain;

namespace Products.Api.Application.Queries
{
    public interface IProductQueries
    {
        Product GetProduct(Guid Id);
    }
}