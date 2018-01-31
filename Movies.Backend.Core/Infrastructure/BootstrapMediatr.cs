using Autofac;
using Autofac.Features.Variance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Backend.Core.Infrastructure
{
   public  class BootstrapMediatr

    {

        public static IMediator BuildMediator(ContainerBuilder builder)
        {

            builder.RegisterSource(new ContravariantRegistrationSource());

            builder.RegisterAssemblyTypes(typeof(IMediator).Assembly).AsImplementedInterfaces();


            builder.Register<SingleInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            builder.Register<MultiInstanceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
            });

            var container = builder.Build().Resolve<IMediator>();
            return container;
        }
    }
}


