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

            Wells.Add(new Models.Well { Id = 1, Name = "��������1", Group = "����1", Field = "��������", Factory = "�����1", ControllerId = 1, OperationType = OperationTypeEnum.����� });
            Wells.Add(new Models.Well { Id = 2, Name = "��������2", Group = "����2", Field = "�����", Factory = "�����2", ControllerId = 2, OperationType = OperationTypeEnum.���});
            Wells.Add(new Models.Well { Id = 3, Name = "��������3", Group = "����3", Field = "�������", Factory = "�����3", ControllerId = 3, OperationType = OperationTypeEnum.��� });
        }
    }
}
