using AutoMapper;
using ProductsApi.Models;
using ProductsApi.Data;

namespace ProductsApi
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductRequestModel, Product>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
        }
    }
}
