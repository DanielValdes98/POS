using POS.Domain.Entities;

namespace POS.Infrastucture.Persistences.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> AccountByUserName(string userName);
    }
}
