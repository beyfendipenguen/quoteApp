namespace _Umuly.WebApi.Models
{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
