using System;
using DMG.DatabaseContext.Repositories;

namespace DMG.DatabaseContext
{
    public class UnitOfWork : IDisposable
    {
        private DataContext _context;

        private UserRepository userRepository;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public UserRepository UserRepository
        {
            get { return userRepository ?? new UserRepository(_context); }
        }


        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
