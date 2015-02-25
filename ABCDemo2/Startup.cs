using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ABCDemo2.Startup))]
namespace ABCDemo2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
