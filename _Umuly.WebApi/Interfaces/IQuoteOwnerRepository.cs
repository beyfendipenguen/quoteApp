using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Interfaces
{
    public interface IQuoteOwnerRepository
    {
        ICollection<QuoteOwner> GetQuoteOwners();
        QuoteOwner GetQuoteOwner(int id);
        QuoteOwner GetQuoteOwnerByEmail(string email);
        bool QuoteOwnerExists(int id);
        bool QuoteOwnerExistsByEmail(string email);
        bool CreateQuoteOwner(QuoteOwner quoteOwner);
        bool UpdateQuoteOwner(QuoteOwner quoteOwner);
        bool DeleteQuoteOwner(QuoteOwner quoteOwner);
        bool Save();
    }
}
