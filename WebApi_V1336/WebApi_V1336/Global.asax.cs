using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using static WebApi_V1336.Models.WellCollection;
using static WebApi_V1336.Models.Well;

namespace WebApi_V1336
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Wells.Add(new Models.Well { Id = 1, Name = "Скважина1", Group = "Куст1", Field = "Качканар", Factory = "Завод1", ControllerId = 1, OperationType = OperationTypeEnum.ГПШГН });
            Wells.Add(new Models.Well { Id = 2, Name = "Скважина2", Group = "Куст2", Field = "Пермь", Factory = "Завод2", ControllerId = 2, OperationType = OperationTypeEnum.ЭВН});
            Wells.Add(new Models.Well { Id = 3, Name = "Скважина3", Group = "Куст3", Field = "Луганск", Factory = "Завод3", ControllerId = 3, OperationType = OperationTypeEnum.ЭЦН });
        }
    }
}
