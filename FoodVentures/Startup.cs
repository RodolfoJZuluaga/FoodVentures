using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FoodVentures.Startup))]
namespace FoodVentures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
