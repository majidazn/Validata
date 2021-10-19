using Autofac;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Validata.ApplicationServices.Customer.Commands.CreateCustomerCommand;

namespace Validata.ApplicationServices.Infrastrutures
{
    public class ApplicationServiceSetupDependency : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            #region MediatoR
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces().InstancePerLifetimeScope();

            // request & notification handlers
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });


            builder.RegisterAssemblyTypes(typeof(CreateCustomerCommand).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IRequestHandler<,>));


            // Register the Command's Validators (Validators based on FluentValidation library)
            builder
                .RegisterAssemblyTypes(typeof(CreateCustomerCommandValidator).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();



         
            #endregion

            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
            //    .Where(x => x.Namespace.StartsWith("Validata.ApplicationServices.CommonServices"))
            //    .AsImplementedInterfaces()
            //    .InstancePerLifetimeScope();

           // builder.RegisterType<CenterDomainServices>().As<ICenterDomainServices>().InstancePerLifetimeScope();
           // builder.RegisterType<CenterVariableDomainServices>().As<ICenterVariableDomainServices>().InstancePerLifetimeScope();
        }
    }
}
