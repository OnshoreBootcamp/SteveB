using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAutoCrossClub.Startup))]
namespace MVCAutoCrossClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
