using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Data;
using _Umuly.WebApi.Models;
using _Umuly.WebApi.Dto;

namespace _Umuly.WebApi.Repository
{
    public class CityRepository : ICityRepository
    {
        private DataContext _context;
        public CityRepository(DataContext context)
        {
            _context = context;
        }

        public bool CityExists(int id)
        {
            return _context.Cities.Any(c => c.Id == id);
        }

        public bool CreateCity(City city)
        {
            _context.Add(city);
            return Save();
        }

        public bool DeleteCity(City city)
        {
            _context.Remove(city);
            return Save();
        }
        
        public ICollection<CityWithCountry> GetCities()
        {
            return _context.Cities.Join(_context.Countries,
                city => city.Country.Id,
                country => country.Id,
                (city, country) => new CityWithCountry
                {
                    Id = city.Id,
                    CityName = city.CityName,
                    Country = new CountryDto
                    {
                        Id = country.Id,
                        CountryName = country.CountryName
                    }
                }).ToList();

        }
        
        public City GetCity(int id)
        {
            return _context.Cities.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCity(City city)
        {
            _context.Update(city);
            return Save();
        }
    }
}
