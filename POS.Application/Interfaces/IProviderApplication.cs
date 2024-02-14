using POS.Application.Commons.Bases;
using POS.Application.DTOs.Provider.Request;
using POS.Application.DTOs.Provider.Response;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;

namespace POS.Application.Interfaces
{
    public interface IProviderApplication
    {
        Task<BaseResponse<BaseEntityResponse<ProviderResponseDTO>>> ListProviders(BaseFiltersRequest filters);
        Task<BaseResponse<ProviderResponseDTO>> ProviderById(int providerId);
        Task<BaseResponse<bool>> RegisterProvider(ProviderRequestDTO requestDTO);
        Task<BaseResponse<bool>> EditProvider(int providerId, ProviderRequestDTO requestDTO);
        Task<BaseResponse<bool>> RemoveProvider (int providerId);
    }
}
