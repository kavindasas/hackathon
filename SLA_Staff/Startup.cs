using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SLA_Staff.Startup))]
namespace SLA_Staff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
