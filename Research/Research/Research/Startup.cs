using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Research.Startup))]
namespace Research
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
