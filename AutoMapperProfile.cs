using AutoMapper;
using SalesProject.Entities;
using SalesProject.Models.Campaign.DTO;
using SalesProject.Models.Product.Response;

namespace SalesProject
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Product,ProductGetAllResponse>().ReverseMap();
            CreateMap<Product, ProductAddProductResponse>().ReverseMap();
            CreateMap<Campaign, CampaignDto>().ReverseMap();
        }
    }
}
