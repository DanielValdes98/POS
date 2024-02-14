using AutoMapper;
using POS.Application.Commons.Bases;
using POS.Application.DTOs.Provider.Request;
using POS.Application.DTOs.Provider.Response;
using POS.Application.Interfaces;
using POS.Domain.Entities;
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

        public async Task<BaseResponse<ProviderResponseDTO>> ProviderById(int providerId)
        {
            var response = new BaseResponse<ProviderResponseDTO>();
            var provider = await _unitOfWork.Provider.GetByIdAsync(providerId);

            if (provider is not null)
            {
                response.IsSuccess = true;
                response.Data = _mapper.Map<ProviderResponseDTO>(provider);
                response.Message = ReplyMessage.MESSAGE_QUERY;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> RegisterProvider(ProviderRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var provider = _mapper.Map<Provider>(requestDTO);

            response.Data = await _unitOfWork.Provider.RegisterAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_SAVE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILDED;
            }

            return response;
        }

        public async Task<BaseResponse<bool>> EditProvider(int providerId, ProviderRequestDTO requestDTO)
        {
            var response = new BaseResponse<bool>();
            var providerByID = await ProviderById(providerId);

            if (providerByID.Data is null)
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_QUERY_EMPTY;
                
                return response;
            }
            
            var provider = _mapper.Map<Provider>(requestDTO);
            provider.Id = providerId;
            response.Data = await _unitOfWork.Provider.EditAsync(provider);

            if (response.Data)
            {
                response.IsSuccess = true;
                response.Message = ReplyMessage.MESSAGE_UPDATE;
            }
            else
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_FAILDED;
            }

            return response;
        }
    }
}
