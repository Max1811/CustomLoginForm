using AutoMapper;
using DecisionSupport.API.Models;
using DecisionSupport.BL.Models;
using DecisionSupport.DataAccess.Entities;

namespace DecisionSupport.API.Mapper
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
