namespace _Umuly.WebApi.Models
{
    public class City : BaseEntity
    {
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string CityName { get; set; }
        public ICollection<Quote> FromCityQuotes { get; set; }
        public ICollection<Quote> ToCityQuotes { get; set; }

    }
}
