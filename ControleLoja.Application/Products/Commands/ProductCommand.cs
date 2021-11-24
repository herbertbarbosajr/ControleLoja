using ControleLoja.Domain.Entities;
using MediatR;

namespace ControleLoja.Application.Products.Commands
{
    public abstract class ProductCommand : IRequest<Product>
    {
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public decimal Preço { get; set; }
        public int Estoque { get; set; }
        public string Imagem { get; set; }
        public int CategoriaId { get; set; }
    }
}
