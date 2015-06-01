using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Werkverantwoording.Startup))]
namespace Werkverantwoording
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
