using AutoMapper;
using jim.models.Dto.Msg;
using jim.models.Entity.Msgs;

namespace jim.api.Mapper
{
    public class MsgProfile : Profile
    {
        public MsgProfile()
        {
            CreateMap<Msg, MsgDto>();
        }
    }
}
