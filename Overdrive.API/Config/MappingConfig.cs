using AutoMapper;
using Overdrive.API.Data.ValueObject.Request;
using Overdrive.API.Data.ValueObject.Response;
using Overdrive.API.Model;

namespace Overdrive.API.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps() 
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CompanyCreate, Company>().ReverseMap();
                config.CreateMap<CompanyUpdate, Company>().ReverseMap();
                config.CreateMap<CompanyAndPeople, Company>().ReverseMap();
                config.CreateMap<CompanyResponse, Company>().ReverseMap();

                config.CreateMap<PeopleCreate, People>().ReverseMap();
                config.CreateMap<PeopleUpdate, People>().ReverseMap();
                config.CreateMap<PeopleResponse, People>().ReverseMap();
                

                config.CreateMap<AddressResponse, Address>().ReverseMap();
            } );
            return mappingConfig;
        }

    }
}
