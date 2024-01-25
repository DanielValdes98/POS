using POS.Application.Commons.Bases;
using POS.Application.DTOs.Category.Request;
using POS.Application.DTOs.Category.Response;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;

namespace POS.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task<BaseResponse<BaseEntityResponse<CategoryResponseDTO>>> ListCategories(BaseFiltersRequest filters);
        Task<BaseResponse<IEnumerable<CategorySelectResponseDTO>>> ListSelectCategories();
        Task<BaseResponse<CategoryResponseDTO>> CategoryById(int categoryId);
        Task<BaseResponse<bool>> RegisterCategory(CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditCategory(int categoryId, CategoryRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveCategory(int categoryId);
    }
}
