using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nguyenthihoangduong_Lab456__.Startup))]
namespace Nguyenthihoangduong_Lab456__
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
