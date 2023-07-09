using AutoMapper;
using ShopStore.API.Dto;
using ShopStore.Data.Models;

namespace ShopStore.API.Mapping;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Category, CategoryDto>();
    }
}

