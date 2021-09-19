using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FullyProject.Startup))]
namespace FullyProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
