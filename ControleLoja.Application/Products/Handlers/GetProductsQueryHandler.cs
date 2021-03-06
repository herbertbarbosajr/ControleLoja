using ControleLoja.Application.Products.Queries;
using ControleLoja.Domain.Entities;
using ControleLoja.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ControleLoja.Application.Products.Handlers
{
    public class GetSalesQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public GetSalesQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, 
            CancellationToken cancellationToken)
        {
            return await _productRepository.GetProductsAsync();
        }
    }
}
