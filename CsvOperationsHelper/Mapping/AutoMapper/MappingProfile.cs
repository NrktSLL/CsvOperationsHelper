using AutoMapper;
using CsvOperationsHelper.Data.Models;
using CsvOperationsHelper.Dto;

namespace CsvOperationsHelper.Mapping.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
