using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(isMerkeziSistemi.Startup))]
namespace isMerkeziSistemi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
