namespace _Umuly.WebMvc.Models

{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public Country Country { get; set; }
    }
}
