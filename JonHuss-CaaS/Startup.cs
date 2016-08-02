using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JonHuss_CaaS.UserInterface.Startup))]
namespace JonHuss_CaaS.UserInterface
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
