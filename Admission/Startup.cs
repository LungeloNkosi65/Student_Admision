using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Admission.Startup))]
namespace Admission
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
