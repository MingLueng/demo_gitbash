using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FestivalMarket.Startup))]
namespace FestivalMarket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
