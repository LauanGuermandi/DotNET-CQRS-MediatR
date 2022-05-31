namespace Products.Api.Domain
{
    public interface IProductRepository
    {
        void AddProduct(Product product);
        void SyncProduct(Product product);
        Product GetProduct(Guid Id);
    }
}
