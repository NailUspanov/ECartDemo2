using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ECartDemo2.Startup))]
namespace ECartDemo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
