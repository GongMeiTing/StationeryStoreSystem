using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StationeryStoreSystem.Startup))]
namespace StationeryStoreSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
