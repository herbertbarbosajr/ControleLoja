using AutoMapper;
using ControleLoja.Application.DTO;
using ControleLoja.Application.Products.Commands;


namespace ControleLoja.Application.Mapping
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
