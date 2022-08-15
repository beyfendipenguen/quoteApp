
namespace _Umuly.WebMvc.Models

{
    public class QuoteOwner : BaseEntity
    {
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string? CompanyName { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }

}
