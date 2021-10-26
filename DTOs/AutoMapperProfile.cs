using AutoMapper;
using ListApi.Models;
using ListApi.DTO;
namespace automapper_sample;


public class AutoMapperProfile : Profile
{
  public AutoMapperProfile()
  {
    CreateMap<User, UserDTO>().ReverseMap();
  }
}
