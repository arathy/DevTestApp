using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DevTestApp.Startup))]
namespace DevTestApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
