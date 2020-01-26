using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PeopleDir.Startup))]
namespace PeopleDir
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
