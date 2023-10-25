using Autofac;
using Clean.Architecture.Core.Interfaces;
using Clean.Architecture.Core.Services;
using Clean.Architecture.Core.Services.PersonAggregate;

namespace Clean.Architecture.Core;

/// <summary>
/// An Autofac module that is responsible for wiring up services defined in the Core project.
/// </summary>
public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<DeleteContributorService>()
        .As<IDeleteContributorService>().InstancePerLifetimeScope();
    builder.RegisterType<IDeletePersonService>()
    .As<DeletePersonService>().InstancePerLifetimeScope();
    builder.RegisterType<ICreatePersonService>()
    .As<CreatePersonService>().InstancePerLifetimeScope();
    builder.RegisterType<IUpdatePersonService>()
    .As<UpdatePersonService>().InstancePerLifetimeScope();
    
  }
}
