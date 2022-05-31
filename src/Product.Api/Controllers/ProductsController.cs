using MediatR;
using Microsoft.AspNetCore.Mvc;
using Products.Api.Application.Commands;
using Products.Api.Application.Queries;
using Products.Api.Domain;

namespace Products.Api.Controllers
{
    [ApiController]
    [Route("api/produtos")]
    public class ProductsController : Controller
    {
        private readonly IMediator _mediatr;
        private readonly IProductQueries _productQueries;

        public ProductsController(IMediator mediatr, IProductQueries productQueries)
        {
            _mediatr = mediatr;
            _productQueries = productQueries;
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(AddProductCommand product)
        {
            await _mediatr.Send(product);
            return NoContent();
        }

        [HttpGet("{idProduct}")]
        public ActionResult<Product> GetProduct(Guid idProduct)
        {
            return _productQueries.GetProduct(idProduct);
        }
    }
}
