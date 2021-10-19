using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Validata.DataAccess.Context;

namespace Validata.DataAccess.Infrastrutures
{
    public class DataAccessSetupDependency : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            //builder.RegisterAssemblyModules(typeof(ApplicationServiceSetupDependency).Assembly);
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //     .Where(x => x.Namespace.StartsWith("Validata.ApplicationServices.Infrastrutures"))


          builder.RegisterAssemblyModules(Assembly.Load("Validata.ApplicationServices"));


            builder.RegisterType<ECommerceBoundedContextCommand>().As<DbContext>().InstancePerLifetimeScope();
            builder.RegisterType<ECommerceBoundedContextQuery>().InstancePerLifetimeScope();


            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                 .Where(x => x.Namespace.StartsWith("Validata.DataAccess.Repositories"))
                 .AsImplementedInterfaces()
                 .InstancePerLifetimeScope();


        }
    }
}
