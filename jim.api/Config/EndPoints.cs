using jim.api.Hubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace jim.api.Config
{
    public static class EndPoints
    {
        public static void Config(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapHub<MessageHub>("/Hub/Message");
            endpoints.MapControllers();
        }
    }
}
