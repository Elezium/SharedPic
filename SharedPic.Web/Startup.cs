using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SharedPic.Web.Startup))]
namespace SharedPic.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
			ConfigureDependencyInjection(app);
			ConfigureAuth(app);
        }
    }
}
