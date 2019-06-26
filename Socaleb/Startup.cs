using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Socaleb.Startup))]
namespace Socaleb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
