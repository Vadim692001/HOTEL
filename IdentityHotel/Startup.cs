using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityHotel.Startup))]
namespace IdentityHotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
