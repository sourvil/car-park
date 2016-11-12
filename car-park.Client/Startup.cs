using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(car_park.Client.Startup))]
namespace car_park.Client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
