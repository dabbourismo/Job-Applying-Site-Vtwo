using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityComponents.Startup))]
namespace IdentityComponents
{
    public partial class Startup
    {
        //herereeeeeeeeeeeeeeeeeeeeee
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
