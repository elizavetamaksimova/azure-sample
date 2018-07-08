using AutoMapper;
using AzurePlayArea.BL.Models;
using AzurePlayArea.Models;

namespace AzurePlayArea.AutoMapper.Profiles
{
    public class PresentationLayerProfile : Profile
    {
        public PresentationLayerProfile()
        {
            RegisterProductMapping();
        }

        public void RegisterProductMapping()
        {
            CreateMap<Product, ProductEntity>();
        }
    }
}