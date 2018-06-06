using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjectAO_Wagenpark.Startup))]
namespace ProjectAO_Wagenpark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
