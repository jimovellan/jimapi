using jim.common.Errors;
using jim.common.Exceptions;
using jim.models.Entity.Common;
using jim.models.Msgs;
using System;

namespace jim.models.Entity.Msgs
{
    public class Msg : GenericEntity
    {

        public string Body { get; private set; }

      
        public string To { get; private set; }
      
        public MsgType Type { get;  private set; }
        private Msg():base()
        {
            Type = MsgType.BroadCast;
            To = String.Empty;
            Body = String.Empty;
        }

        public static Msg Create(string body)
        {
            var msg = new Msg();
            msg.Body = body;
            msg.Type = MsgType.BroadCast;
            msg.Validate();
            return msg;
        }

        public static Msg Create(string body, string to)
        {
            var msg = new Msg();
            msg.Body = body;
            msg.To = to;
            msg.Type = MsgType.ToUser;
            msg.Validate();
            return msg;
        }

        public override void Validate()
        {
            base.Validate();
            if(Type == MsgType.ToUser)
            {
                if(String.IsNullOrWhiteSpace(To))
                {
                    var msg = Validation.ThePropertyIsNullOrEmpty(nameof(To), this.NameOfEntity);
                    throw new ValidationCustomException(this.GetType(), nameof(To), msg);
                }
            }
           

            if (String.IsNullOrWhiteSpace(Body))
            {
                var msg = Validation.ThePropertyIsNullOrEmpty(nameof(Body), this.NameOfEntity);
                throw new ValidationCustomException(this.GetType(), nameof(Body), msg);
            }
        }

    }
}
