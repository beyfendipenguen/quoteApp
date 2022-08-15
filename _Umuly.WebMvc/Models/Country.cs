namespace _Umuly.WebMvc.Models

{
    public class Country : BaseEntity
    {
        public string CountryName { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
