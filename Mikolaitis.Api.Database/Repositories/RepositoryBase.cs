using System;
using System.Diagnostics;

namespace Mikolaitis.Api.Database.Repositories
{
    public abstract class RepositoryBase
    {
        protected readonly MikolaitisApiDbContext Context = new MikolaitisApiDbContext();

        #region IDisposable

        protected bool _isDisposed;
        protected void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RepositoryBase()
        {
            Debug.WriteLine("ALERT: Object is not disposed");
            Dispose();
        }

        #endregion
    }
}
