using System;

namespace DMG.DatabaseContext
{
    public class UnitOfWork : IDisposable
    {
        private DataContext context;

        private UserRepository userRepository;

        public UnitOfWork(DataContext _context)
        {
            context = _context;
        }

        public UserRepository UserRepository
        {
            get { return userRepository ?? new UserRepository(context); }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
