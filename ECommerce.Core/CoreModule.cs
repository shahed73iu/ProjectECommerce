using Autofac;
using ECommerce.Core.Contexts;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.Extensions.Configuration;

namespace ECommerce.Core
{
    public class CoreModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly IConfiguration _configuration;

        public CoreModule(IConfiguration configuration, string connectionStringName, string migrationAssemblyName)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString(connectionStringName);
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreContext>().As<IStoreContext>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<StoreUnitOfWork>().As<IStoreUnitOfWork>()
                   .WithParameter("connectionString", _connectionString)
                   .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                   .InstancePerLifetimeScope();

            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<CategoryService>().As<ICategoryService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepositroy>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>()
               .InstancePerLifetimeScope();

            builder.RegisterType<StockRepository>().As<IStockRepository>()
            .InstancePerLifetimeScope();
            builder.RegisterType<StockService>().As<IStockService>()
              .InstancePerLifetimeScope();


            builder.RegisterType<ImageRepository>().As<IImageRepository>()
               .InstancePerLifetimeScope();
            builder.RegisterType<ImageService>().As<IImageService>()
               .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
