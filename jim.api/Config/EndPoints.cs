using jim.api.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace jim.api.Config
{
    public static class EndPoints
    {

        public const string HUB_END_POINT = "/Hub/Message";

        public static void Config(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<MessageHub>(HUB_END_POINT);
            endpoints.MapControllers();
        }
    }
}
