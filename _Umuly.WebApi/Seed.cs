using _Umuly.WebApi.Data;
using _Umuly.WebApi.Models;

namespace _Umuly.WebApi
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Countries.Any())
            {
                    var countries = new List<Country>()
                {
                    new Country()
                    {
                        CountryName="USA",
                        Cities=new List<City>()
                        {
                            new City(){ CityName="New York"},
                            new City(){ CityName="Los Angeles"},
                            new City(){ CityName="Miami"},
                            new City(){ CityName="Minnesota"},
                        }

                    },
                    new Country()
                    {
                        CountryName="CHINA",
                        Cities=new List<City>()
                        {
                            new City(){CityName="Beijing"},
                            new City(){CityName="Shanghai"},

                        }
                    },
                    new Country()
                    {
                   
                        CountryName="TURKIYE",
                        Cities=new List<City>()
                        {
                            new City(){ CityName="İstanbul"},
                            new City(){ CityName="İzmir"},
                        }

                    },
                };
                dataContext.Countries.AddRange(countries);
                dataContext.SaveChanges();
            }
            if (!dataContext.Currencies.Any())
            {
                var currencies = new List<Currency>()
                {
                    new Currency() { CurrencyName="US Dollar",CurrencyCode="USD" },
                    new Currency() {  CurrencyName="Chinese Yuan",CurrencyCode="CNY" },
                    new Currency() { CurrencyName="Turkish Lira",CurrencyCode="TRY" }
                };
                dataContext.Currencies.AddRange(currencies);
                dataContext.SaveChanges();
            }
        }
    }
}
