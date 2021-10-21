using Autofac;
using Validata.DataAccess.Infrastrutures;

namespace Validata.WebApi.Framework.Infrastrutures
{
    public class WebSetupDependency : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterAssemblyModules(typeof(DataAccessSetupDependency).Assembly);


        }
    }

}
