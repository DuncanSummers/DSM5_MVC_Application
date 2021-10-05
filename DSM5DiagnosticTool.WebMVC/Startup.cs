using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DSM5DiagnosticTool.WebMVC.Startup))]
namespace DSM5DiagnosticTool.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
