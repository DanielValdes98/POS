using AutoMapper;
using POS.Application.Commons.Bases;
using POS.Application.DTOs.Provider.Response;
using POS.Application.Interfaces;
using POS.Infrastucture.Commons.Bases.Request;
using POS.Infrastucture.Commons.Bases.Response;
using POS.Infrastucture.Persistences.Interfaces;
using POS.Utilities.Static;

namespace POS.Application.Services
{
    public class ProviderApplication : IProviderApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProviderApplication(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<BaseEntityResponse<ProviderResponseDTO>>> ListProviders(BaseFiltersRequest filters)
        {
            var response = new BaseResponse<BaseEntityResponse<ProviderResponseDTO>>();
            var providers = await _unitOfWork.Provider.ListProviders(filters);

            if (providers is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<BaseEntityResponse<ProviderResponseDTO>>(providers);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }
    }
}
