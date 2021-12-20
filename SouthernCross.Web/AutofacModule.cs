using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SouthernCross.Data;
using SouthernCross.Data.Context;
using SouthernCross.Persistence;
using SouthernCross.Web.Services;

namespace SouthernCross.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<MemberService> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method. All of this starts
            // with the `UseServiceProviderFactory(new AutofacServiceProviderFactory())` that happens in Program and registers Autofac
            // as the service provider.
            builder.RegisterInstance(new LiteDbOptions());

            builder.Register(c => new LiteDbContext(c.Resolve<IOptions<LiteDbOptions>>())).As<ILiteDbContext>().SingleInstance();

            builder.Register(c => new UnitOfWork(c.Resolve<ILiteDbContext>())).As<IUnitOfWork>().InstancePerLifetimeScope();

            builder.Register(c => new MemberService(c.Resolve<ILogger<MemberService>>(), c.Resolve<IUnitOfWork>()))
                   .As<IMemberService>()
                   .InstancePerLifetimeScope();
        }
    }
}
