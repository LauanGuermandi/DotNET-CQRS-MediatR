using Products.Api.Domain;

namespace Products.Api.Application.Queries
{
    public class ProductQueries : IProductQueries
    {
        private readonly IProductRepository _productRepository;

        public ProductQueries(IProductRepository productRepository)
            => _productRepository = productRepository;

        public Product GetProduct(Guid Id)
            => _productRepository.GetProduct(Id);
    }
}
