using ControleLoja.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleLoja.Application.Products.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}

