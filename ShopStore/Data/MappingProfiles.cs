using System;
using AutoMapper;
using ShopStore.Dto;
using ShopStore.Models;

namespace ShopStore.Data;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
            CreateMap<User, UserDto>();
	}
}

