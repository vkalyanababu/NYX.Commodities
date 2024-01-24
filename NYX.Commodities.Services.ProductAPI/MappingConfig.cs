using AutoMapper;
using NYX.Commodities.Services.ProductAPI.Models;
using NYX.Commodities.Services.ProductAPI.Models.Dtos;

namespace NYX.Commodities.Services.ProductAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterConfig()
        {
            var mappingConfig = new MapperConfiguration(config =>
                config.CreateMap<ProductDto, Product>().ReverseMap()
            );

            return mappingConfig;
        }
    }
}
