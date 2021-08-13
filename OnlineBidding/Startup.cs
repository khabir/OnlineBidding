using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineBidding.Startup))]
namespace OnlineBidding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
