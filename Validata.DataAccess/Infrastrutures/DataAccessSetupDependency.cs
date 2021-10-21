using Autofac;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Validata.DataAccess.Context;

namespace Validata.DataAccess.Infrastrutures
{
    public class DataAccessSetupDependency : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);


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
