using AutoMapper;
using jim.models.Dto.User;
using jim.models.Entity.Users;

namespace jim.api.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}
