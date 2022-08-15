using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Models;
using AutoMapper;

namespace _Umuly.WebApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<City, CityDto>();
            CreateMap<CityDto, City>();

            CreateMap<Country, CountryDto>();
            CreateMap<CountryDto, Country>();

            CreateMap<Currency, CurrencyDto>();
            CreateMap<CurrencyDto, Currency>();

            CreateMap<Quote, QuoteDto>();
            CreateMap<QuoteDto, Quote>();

            CreateMap<QuoteOwner, QuoteOwnerDto>();
            CreateMap<QuoteOwnerDto, QuoteOwner>();

        }
    }
}
