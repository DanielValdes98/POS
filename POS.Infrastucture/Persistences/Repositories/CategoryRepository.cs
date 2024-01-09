using POS.Domain.Entities;
using POS.Infrastucture.Persistences.Context;
using POS.Infrastucture.Persistences.Interfaces;

namespace POS.Infrastucture.Persistences.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        private readonly PosContext _context;

        public CategoryRepository(PosContext posContext)
        {
            _context = posContext;
        }
    }
}
