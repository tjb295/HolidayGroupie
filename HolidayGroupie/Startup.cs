using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HolidayGroupie.Startup))]
namespace HolidayGroupie
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
