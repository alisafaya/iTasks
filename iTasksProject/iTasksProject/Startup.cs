using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(iTasksProject.Startup))]
namespace iTasksProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
