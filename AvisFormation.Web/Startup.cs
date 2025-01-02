using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AvisFormation.Web.Startup))]
namespace AvisFormation.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
