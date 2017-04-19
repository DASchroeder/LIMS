using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lims.Startup))]
namespace Lims
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
