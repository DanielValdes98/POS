using AutoMapper;
using POS.Application.DTOs.Request;
using POS.Application.DTOs.Response;
using POS.Domain.Entities;
using POS.Infrastucture.Commons.Bases.Response;
using POS.Utilities.Static;

namespace POS.Application.Mappers
{
    public class CategoryMappingsProfile : Profile
    {
        public CategoryMappingsProfile()
        {
            CreateMap<Category, CategoryResponseDTO>()
                .ForMember(x => x.StateCegory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDTO>>()
                .ReverseMap();

            CreateMap<CategoryRequestDTO, Category>();

            CreateMap<Category, CategorySelectResponseDTO>()
                .ReverseMap();
        }
    }
}
