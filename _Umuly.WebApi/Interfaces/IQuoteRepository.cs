using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Interfaces
{
    public interface IQuoteRepository
    {
        ICollection<Quote> GetQuotes();
        Quote GetQuote(int id);
        bool QuoteExists(int id);
        bool CreateQuote(Quote quote);
        bool UpdateQuote(Quote quote);
        bool DeleteQuote(Quote quote);
        bool Save();
    }
}
