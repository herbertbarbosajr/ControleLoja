using ControleLoja.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace ControleLoja.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
