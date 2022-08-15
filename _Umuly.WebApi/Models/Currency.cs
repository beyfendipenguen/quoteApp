
namespace _Umuly.WebApi.Models
{
    public class Currency : BaseEntity

    {
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public ICollection<Quote> Quotes { get; set; }
    }
}
