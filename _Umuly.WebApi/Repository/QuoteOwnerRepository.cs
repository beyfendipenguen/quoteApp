using _Umuly.WebApi.Data;
using _Umuly.WebApi.Interfaces;
using _Umuly.WebApi.Models;

namespace _Umuly.WebApi.Repository
{
    public class QuoteOwnerRepository : IQuoteOwnerRepository
    {
        private DataContext _dataContext;
        public QuoteOwnerRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public bool CreateQuoteOwner(QuoteOwner quoteOwner)
        {
            _dataContext.Add(quoteOwner);
            return Save();
        }

        public bool DeleteQuoteOwner(QuoteOwner quoteOwner)
        {
            _dataContext.Remove(quoteOwner);
            return Save();
        }

        public QuoteOwner GetQuoteOwner(int id)
        {
            return _dataContext.QuoteOwners.Where(q => q.Id == id).FirstOrDefault();
        }
        public QuoteOwner GetQuoteOwnerByEmail(string email)
        {
            return _dataContext.QuoteOwners.Where(qo => qo.Email == email).FirstOrDefault();
        }

        public ICollection<QuoteOwner> GetQuoteOwners()
        {
            return _dataContext.QuoteOwners.ToList();
        }

        public bool QuoteOwnerExists(int id)
        {
            return _dataContext.QuoteOwners.Any(q => q.Id == id);
        }
        public bool QuoteOwnerExistsByEmail(string email)
        {
            return _dataContext.QuoteOwners.Any(q => q.Email == email);
        }

        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateQuoteOwner(QuoteOwner quoteOwner)
        {
            _dataContext.Update(quoteOwner);
            return Save();
        }

    }
}
