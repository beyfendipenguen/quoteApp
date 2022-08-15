namespace _Umuly.WebApi.Dto
{
    public class CityWithCountry
    {
        public int Id { get; set; }
        public string CityName { get; set; }
        public CountryDto Country { get; set; }
    }
}
