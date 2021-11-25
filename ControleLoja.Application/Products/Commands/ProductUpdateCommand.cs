using System;
using System.Collections.Generic;
using System.Text;

namespace ControleLoja.Application.Products.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
