using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(benhvien.Startup))]
namespace benhvien
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
