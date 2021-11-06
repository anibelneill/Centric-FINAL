using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Centric_FINAL.Startup))]
namespace Centric_FINAL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
