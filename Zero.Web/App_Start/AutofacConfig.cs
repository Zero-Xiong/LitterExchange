//using Autofac;
//using Autofac.Integration.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;
//using Zero.Common;
//using Zero.Service;

//namespace Zero.Web
//{
//    public class AutofacConfig
//    {
//        public static void ConfigureContainer()
//        {
//            var builder = new ContainerBuilder();

//            builder.RegisterControllers(Assembly.GetExecutingAssembly());
//            builder.RegisterAssemblyTypes(typeof(CategoryService).Assembly).Where(c => c.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerRequest();
//            //builder.RegisterType<ItemService>().As<IItemService>().InstancePerRequest();
//            builder.RegisterType<SysLog>().As<ISysLog>().InstancePerMatchingLifetimeScope();

//            // Set the MVC dependency resolver to use Autofac
//            var container = builder.Build();
//            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
//        }
//    }
//}
