using AutoMapper;
using CaWorkshop.Application.Common.Mappings;

namespace CaWorkshop.Application.UnitTests;

public static class MapperFactory
{
    public static IMapper Create()
    {
        var configurationProvider = new MapperConfiguration(config =>
        {
            config.AddProfile<MappingProfile>();
        });

        return configurationProvider.CreateMapper();
    }
}
