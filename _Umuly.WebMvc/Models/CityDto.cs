namespace _Umuly.WebMvc.Models

{
    public class CityDto : BaseEntity
    {
        public int CountryId { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public Country Country { get; set; }
    }
}
