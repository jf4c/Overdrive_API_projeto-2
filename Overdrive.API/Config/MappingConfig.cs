using AutoMapper;
using Overdrive.API.Data.ValueObject;
using Overdrive.API.Model;

namespace Overdrive.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CompanyVO, Company>().ReverseMap();
                config.CreateMap<PeopleVO, People>().ReverseMap();
                config.CreateMap<AddressVO, Address>().ReverseMap();
                config.CreateMap<DocumentVO, Document>().ReverseMap();
            } );
            return mappingConfig;
        }

    }
}
