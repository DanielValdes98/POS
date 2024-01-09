using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;

namespace POS.Infrastucture.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PosContext _context;
        public ICategoryRepository Category { get; private set; }

        public UnitOfWork(PosContext posContext)
        {
            _context = posContext;
            Category = new CategoryRepository(_context);
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
