using AutoMapper;
using CsvOperationsHelper.Data.Dto;
using CsvOperationsHelper.Data.Models;

namespace CsvOperationsHelper.Business.Helper.Mapping.AutoMapper
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
