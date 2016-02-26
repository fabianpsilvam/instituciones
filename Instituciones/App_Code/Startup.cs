using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Instituciones.Startup))]
namespace Instituciones
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
