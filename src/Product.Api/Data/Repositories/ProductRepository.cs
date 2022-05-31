using Products.Api.Data.Context;
using Products.Api.Domain;

namespace Products.Api.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductWriteContext _writeContext;
        private readonly ProductReadContext _readContext;

        public ProductRepository(ProductWriteContext writeContext, ProductReadContext readContext)
        {
            _writeContext = writeContext;
            _readContext = readContext;
        }

        public void AddProduct(Product product)
        {
            _writeContext.Products.Add(product);
            _writeContext.SaveChanges();
        }

        public Product GetProduct(Guid Id)
            => _readContext.Products.First(p => p.Id == Id);

        public void SyncProduct(Product product)
        {
            _readContext.Products.Add(product);
            _readContext.SaveChanges();
        }
    }
}
