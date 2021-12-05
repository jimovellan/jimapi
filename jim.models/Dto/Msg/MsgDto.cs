using jim.models.Msgs;

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
