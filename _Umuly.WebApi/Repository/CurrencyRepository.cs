using _Umuly.WebApi.Data;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Repository
{
    public class CurrencyRepository : ICurrencyReposityory
    {
        private DataContext _context;
        public CurrencyRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateCurrency(Currency currency)
        {
            _context.Add(currency);
            return Save();
        }

        public bool CurrencyExists(int id)
        {
            return _context.Currencies.Any(c => c.Id == id);
        }

        public bool DeleteCurrency(Currency currency)
        {
            _context.Remove(currency);
            return Save();
        }

        public ICollection<Currency> GetCurrencies()
        {
            return _context.Currencies.ToList();
        }

        public Currency GetCurrency(int id)
        {
            return _context.Currencies.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCurrency(Currency currency)
        {
            _context.Update(currency);
            return Save();
        }
    }
}
