using MediatR;
using Products.Api.Domain;

namespace Products.Api.Application.Events
{
    public class NewProductEvent : INotification
    {
        public Product Product { get; set; }
    }
}
