using FrontAsignacionActivoFijo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FrontAsignacionActivoFijo.Startup))]
namespace FrontAsignacionActivoFijo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            //createUsuarios();
        }

        private void createUsuarios()
        {

            ApplicationDbContext context = new ApplicationDbContext();
           
            var userManager = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));           
                var user = new ApplicationUser();
                user.UserName = "E022044";
                user.Email = "e022044@econtactsol.com";
                userManager.Create(user, "Ee022044!");
                       
        }
    }
}
