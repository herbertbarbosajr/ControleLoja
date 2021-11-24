using ControleLoja.Application.Products.Commands;
using ControleLoja.Domain.Entities;
using ControleLoja.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleLoja.Application.Products.Handlers
{
    public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductCreateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Product> Handle(ProductCreateCommand request, 
            CancellationToken cancellationToken)
        {
            var product = new Product(request.Nome, request.Descrição, request.Preço,
                              request.Estoque, request.Imagem);

            if (product == null)
            {
                throw new ApplicationException($"Error creating entity.");
            }
            else
            {
                product.CategoriaId = request.CategoriaId;
                return await _productRepository.CreateAsync(product);
            }
        }
    }
}
