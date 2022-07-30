using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ident.Startup))]
namespace ident
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
