using AutoMapper;
using LoginForm.API.Models;
using LoginForm.BL.Models;
using LoginForm.DataAccess.Entities;

namespace LoginForm.API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpDto, SignUpModel>();
            CreateMap<SignUpModel, User>();
        }
    }
}
