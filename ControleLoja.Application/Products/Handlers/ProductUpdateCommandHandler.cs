using ControleLoja.Application.Products.Commands;
using ControleLoja.Domain.Entities;
using ControleLoja.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControleLoja.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        public ProductUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entidade não pode ser carregada.");
            }
            else
            {
                product.Update(request.Nome, request.Descrição, request.Preço,
                                request.Estoque, request.Imagem, request.CategoriaId);

                return await _productRepository.UpdateAsync(product);

            }
        }
    }
}
