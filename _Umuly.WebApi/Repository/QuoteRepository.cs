using _Umuly.WebApi.Data;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Repository
{
    public class QuoteRepository : IQuoteRepository
    {
        private DataContext _context;

        public QuoteRepository(DataContext context)
        {
            _context = context;
        }
        public bool CreateQuote(Quote quote)
        {
            _context.Quotes.Add(quote);
            return Save();
        }

        public bool DeleteQuote(Quote quote)
        {
            _context.Remove(quote);
            return Save();
        }

        public Quote GetQuote(int id)
        {
            return _context.Quotes.Where(q => q.Id == id).FirstOrDefault();
        }

        public ICollection<Quote> GetQuotes()
        {
            return _context.Quotes.ToList();
        }

        public bool QuoteExists(int id)
        {
            return _context.Quotes.Any(q => q.Id == id);

        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateQuote(Quote quote)
        {
            _context.Update(quote);
            return Save();
        }
    }
}
