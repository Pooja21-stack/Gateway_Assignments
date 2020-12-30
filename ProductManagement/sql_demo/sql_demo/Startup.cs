using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(sql_demo.Startup))]
namespace sql_demo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
