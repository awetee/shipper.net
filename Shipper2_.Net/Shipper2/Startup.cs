using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Shipper2.Startup))]
namespace Shipper2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
