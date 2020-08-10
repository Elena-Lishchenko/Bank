using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Transaction.DataAccess;
using Transaction.Models;

[assembly: OwinStartup(typeof(Transaction.App_Start.Startup))]

namespace Transaction.App_Start
{
	public class Startup
	{
		public void Configuration(IAppBuilder app)
		{
			// настраиваем контекст и менеджер
			app.CreatePerOwinContext<BankTransactionDbContext>(BankTransactionDbContext.Create);
			app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

			app.UseCookieAuthentication(new CookieAuthenticationOptions
			{
				AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
				LoginPath = new PathString("/Account/Login"),
			});
		}
	}
}