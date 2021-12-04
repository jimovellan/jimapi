using jim.models.Msgs;
using System;
using System.Collections.Generic;
using System.Text;

namespace jim.models.Dto.Msg
{
    public class MsgDto
    {
        public string Id { get; set; }
        public string Body { get; set; }

        public string To { get; set; }
        
        public MsgType Type { get; set; }
    }
}
