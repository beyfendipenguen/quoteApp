using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Interfaces
{
    public interface ICurrencyReposityory
    {
        ICollection<Currency> GetCurrencies();
        Currency GetCurrency(int id);
        bool CurrencyExists(int id);
        bool CreateCurrency(Currency currency);
        bool UpdateCurrency(Currency currency);
        bool DeleteCurrency(Currency currency);
        bool Save();
    }
}
