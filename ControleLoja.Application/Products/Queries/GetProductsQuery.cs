using ControleLoja.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleLoja.Application.Products.Queries
{
    public class GetProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
