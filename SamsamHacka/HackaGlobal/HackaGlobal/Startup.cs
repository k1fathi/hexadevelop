using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HackaGlobal.Startup))]
namespace HackaGlobal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
