﻿using Autofac;
using NLayer.Caching;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;
using NLayer.Repository;
using NLayer.Repository.Repositories;
using NLayer.Repository.UnitOfWorks;
using NLayer.Service.Services;
using NLayer.Service.Services.Mapping;
using System.Reflection;
using Module = Autofac.Module;

namespace NLayer.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {



            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();


           builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();


            var apiAssembly = Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly= Assembly.GetAssembly(typeof(MapProfile));


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //.InstancePerLifetimeScope() => AddScope()- request başladığından bitene kadar aynı intansı kullansın 
            //.InstancePerDependency => AddTransident()- her seferinde yeni bir intanse oluşturuyor.


            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly)
                .Where(x => x.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductServiceWithCaching>().As<IProductService>();






            base.Load(builder);
        }
    }
}
