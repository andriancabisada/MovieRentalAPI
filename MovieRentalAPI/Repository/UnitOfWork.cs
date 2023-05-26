using Microsoft.EntityFrameworkCore;

namespace MovieRentalAPI.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
