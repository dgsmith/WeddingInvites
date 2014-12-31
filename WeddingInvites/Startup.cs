using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WeddingInvites.Startup))]
namespace WeddingInvites
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
