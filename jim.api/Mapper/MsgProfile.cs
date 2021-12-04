using AutoMapper;
using jim.models.Dto.Msg;
using jim.models.Entity.Msgs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jim.api.Mapper
{
    public class MsgProfile:Profile
    {
        public MsgProfile()
        {
            CreateMap<Msg, MsgDto>();
        }
    }
}
