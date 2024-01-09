using AutoMapper;
using POS.Aplication.Dtos.Request;
using POS.Aplication.Dtos.Response;
using POS.Domain.Entities;
using POS.Infraestructure.Commons.Bases.Response;
using POS.Utilites.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Aplication.Mappers
{
    public class CategoryMappingsProfile: Profile
    {
        public CategoryMappingsProfile()
        {

            CreateMap<Category, CategoryResponseDto>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateCategory, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo"))
                .ReverseMap();

            CreateMap<BaseEntityResponse<Category>, BaseEntityResponse<CategoryResponseDto>>()
                .ReverseMap();

            CreateMap<CategoryRequestDto, Category>();

            CreateMap<Category, CategorySelectResponseDto>()
                .ForMember(x => x.CategoryId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
