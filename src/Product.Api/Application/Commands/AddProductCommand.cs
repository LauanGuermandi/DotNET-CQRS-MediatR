using MediatR;

namespace Products.Api.Application.Commands
{
    public class AddProductCommand : IRequest<bool>
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
