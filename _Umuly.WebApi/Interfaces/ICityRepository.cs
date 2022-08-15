using _Umuly.WebApi.Dto;
using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Interfaces
{
    public interface ICityRepository
    {
        ICollection<CityWithCountry> GetCities();
        City GetCity(int id);
        bool CityExists(int id);
        bool CreateCity(City city);
        bool UpdateCity(City city);
        bool DeleteCity(City city);
        bool Save();
    }
}
