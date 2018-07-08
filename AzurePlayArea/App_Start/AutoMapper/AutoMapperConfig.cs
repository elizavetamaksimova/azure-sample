using AutoMapper;
using AzurePlayArea.AutoMapper.Profiles;

namespace AzurePlayArea.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile(new PresentationLayerProfile());
            });
        }
    }
}