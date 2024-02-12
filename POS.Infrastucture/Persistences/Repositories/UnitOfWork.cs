using Microsoft.Extensions.Configuration;
using POS.Infrastucture.FileStorage;
using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;

namespace POS.Infrastucture.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosContext _context;
        public ICategoryRepository Category { get; private set; }

        public IUserRepository User { get; private set; }

        public IAzureStorage Storage { get; private set; }

        public IProviderRepository Provider { get; private set; }

        public UnitOfWork(PosContext posContext, IConfiguration configuration)
        {
            _context = posContext;
            Category = new CategoryRepository(_context);
            User = new UserRepository(_context);
            Storage = new AzureStorage(configuration);
            Provider = new ProviderRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose(); // Liberar recursos u objetos en memoria
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
