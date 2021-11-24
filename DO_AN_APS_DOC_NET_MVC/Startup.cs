using Microsoft.Owin;
using Owin;
using System.Web.Services.Description;

[assembly: OwinStartupAttribute(typeof(DO_AN_APS_DOC_NET_MVC.Startup))]
namespace DO_AN_APS_DOC_NET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
