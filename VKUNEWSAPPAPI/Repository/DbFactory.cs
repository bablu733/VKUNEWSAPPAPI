using Microsoft.EntityFrameworkCore;

namespace VKUNEWSAPPAPI.Data
{
    public class DbFactory: IDisposable
    {
        private bool _disposed;
        private readonly Func<VKUNEWSAPPAPIDbContext> _instanceFunc;
        private DbContext _dbContext;
        public DbContext DbContext => _dbContext ??= _instanceFunc.Invoke();

        public DbFactory(Func<VKUNEWSAPPAPIDbContext> dbContextFactory)
        {
            _instanceFunc = dbContextFactory;
        }

        public void Dispose()
        {
            if (!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }

}
