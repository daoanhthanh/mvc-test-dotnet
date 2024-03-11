// using be_aspnet_demo.utils;
// using CodeFirstDbGenerator.Metadata.Conventions;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Infrastructure;
// using Microsoft.EntityFrameworkCore.Metadata;
// using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
// using Microsoft.EntityFrameworkCore.Migrations;
//
// namespace be_aspnet_demo.config;
//
// public class AutoMigrationConfig
// {
//     
//     public void Migrate(IApplicationBuilder builder)
//     {
//         using var scope = builder.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope();
//         using var ctx = scope.ServiceProvider.GetRequiredService<AppDbContext>();
//
//         var sp = (ctx as IInfrastructure<IServiceProvider>).Instance;
//
//         var modelDiffer = sp.GetRequiredService<IMigrationsModelDiffer>();
//         var migrationsAssembly = sp.GetRequiredService<IMigrationsAssembly>();
//         var dependencies = sp.GetRequiredService<ProviderConventionSetBuilderDependencies>();
//         var relationalDependencies = sp.GetRequiredService<RelationalConventionSetBuilderDependencies>();
//
//         var a = IModelRuntimeInitializer.Initialize((IModel)ctx.Model);
//         var typeMappingConvention = new TypeMappingConvention(dependencies);
//         typeMappingConvention.ProcessModelFinalizing(((IConventionModel)migrationsAssembly.ModelSnapshot.Model).Builder, null);
//
//         var relationalModelConvention = new RelationalModelConvention(dependencies, relationalDependencies);
//         var sourceModel = relationalModelConvention.ProcessModelFinalized(migrationsAssembly.ModelSnapshot.Model);
//
//         var diffsExist = modelDiffer.HasDifferences(
//             ((IMutableModel)sourceModel).FinalizeModel().GetRelationalModel(),
//             ctx.Model.GetRelationalModel());
//             
//         if(diffsExist)
//         {
//             throw new InvalidOperationException("There are differences between the current database model and the most recent migration.");
//         }
//
//         ctx.Database.Migrate();
//     }
// }