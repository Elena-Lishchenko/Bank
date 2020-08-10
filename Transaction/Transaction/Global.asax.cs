using Microsoft.Practices.Unity.Configuration;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;

namespace Transaction
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			//InitUnityContainer();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}

		//public static void InitUnityContainer()
		//{
		//	var container = new UnityContainer().LoadConfiguration();
		//	container.RegisterType(typeof(IAddendumRolesDistinctor), typeof(AddendumRolesDistinctorBase));
		//	container.RegisterType(typeof(IPrivilegeConfigurator), typeof(PrivilegeConfigurator));

		//	UnityHelper.InitContainer(container);


		//}

	}
}
