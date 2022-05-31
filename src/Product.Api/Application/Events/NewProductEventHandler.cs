using MediatR;
using Products.Api.Domain;

namespace Products.Api.Application.Events
{
    public class NewProductEventHandler : INotificationHandler<NewProductEvent>
    {
        private readonly IProductRepository _productRepository;

        public NewProductEventHandler(IProductRepository productRepository)
            => _productRepository = productRepository;

        public Task Handle(NewProductEvent notification, CancellationToken cancellationToken)
        {
            _productRepository.SyncProduct(notification.Product);
            return Task.FromResult(true);
        }
    }
}
