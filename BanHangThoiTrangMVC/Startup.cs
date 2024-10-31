using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BanHangThoiTrangMVC.Startup))]
namespace BanHangThoiTrangMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
