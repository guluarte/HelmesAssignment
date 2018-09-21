using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HelmesAssignment.Web.Startup))]
namespace HelmesAssignment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
