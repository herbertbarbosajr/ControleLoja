using AutoMapper;
using ControleLoja.Application.DTOs;
using ControleLoja.Application.Products.Commands;

namespace ControleLoja.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<ProductDTO, ProductCreateCommand>();
            CreateMap<ProductDTO, ProductUpdateCommand>();
        }
    }
}
