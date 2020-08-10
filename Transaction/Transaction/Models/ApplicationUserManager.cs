using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Transaction.DataAccess;
using Transaction.Model;

namespace Transaction.Models
{
	public class ApplicationUserManager : UserManager<Operator>
	{
		public ApplicationUserManager(IUserStore<Operator> store)
		 : base(store)
		{
		}
		public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
												IOwinContext context)
		{
			BankTransactionDbContext db = context.Get<BankTransactionDbContext>();
			ApplicationUserManager manager = new ApplicationUserManager(new UserStore<Operator>(db));
			return manager;
		}
	}
}