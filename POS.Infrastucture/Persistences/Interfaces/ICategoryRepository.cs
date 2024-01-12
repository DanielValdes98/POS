using POS.Domain.Entities;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;

namespace POS.Infrastucture.Persistences.Interfaces
{
    public interface ICategoryRepository
    {
        Task<BaseEntityResponse<Category>> ListCategories(BaseFiltersRequest filters);
        Task<IEnumerable<Category>> ListSelectCategories();
        Task<Category> CategoryById(int categoryId);
        Task<bool> RegisterCategory(Category category);
        Task<bool> EditCategory(Category category);
        Task<bool> RemoveCategory(int categoryId);
    }
}
