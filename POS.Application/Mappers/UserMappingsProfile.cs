using AutoMapper;
using POS.Application.DTOs.User.Request;
using POS.Domain.Entities;

namespace POS.Application.Mappers
{
    public class UserMappingsProfile : Profile
    {
        public UserMappingsProfile()
        {
            CreateMap<UserRequestDTO, User>();
            CreateMap<TokenRequestDTO, User>();
        }
    }
}
