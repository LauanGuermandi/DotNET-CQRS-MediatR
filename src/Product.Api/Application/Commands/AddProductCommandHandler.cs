using MediatR;
using Products.Api.Application.Events;
using Products.Api.Domain;

namespace Products.Api.Application.Commands
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMediator _mediator;

        public AddProductCommandHandler(IProductRepository productRepository, IMediator mediator)
        {
            _productRepository = productRepository;
            _mediator = mediator;
        }

        public Task<bool> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price
            };
            _productRepository.AddProduct(product);

            var @event = new NewProductEvent() { Product = product };
            _mediator.Publish(@event);

            return Task.FromResult(true);
        }
    }
}
