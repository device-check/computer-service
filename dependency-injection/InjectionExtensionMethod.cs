using application.Interfaces;
using application.UseCases.BuildingUseCases;
using application.UseCases.CampusUseCases;
using application.UseCases.ComputerPhysicalLocationUseCases;
using application.UseCases.ComputerTypeUseCases;
using application.UseCases.ComputerUseCases;
using application.UseCases.RoomUseCases;
using Asp.Versioning;
using infrastructure.Data;
using infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace dependency_injection
{
    public static class InjectionExtensionMethod
    {

        public static IServiceCollection AddApplicationLayerDependencies(this IServiceCollection serviceCollection)
        {
            // Computer Use Cases
            serviceCollection.AddScoped<GetComputerCountUseCase>();
            serviceCollection.AddScoped<DeleteComputerUseCase>();
            serviceCollection.AddScoped<UpdateComputerUseCase>();
            serviceCollection.AddScoped<AddComputerUseCase>();
            serviceCollection.AddScoped<GetComputerUseCase>();
            

            // ComputerType Use Cases
            serviceCollection.AddScoped<GetComputerTypeCountUseCase>();
            serviceCollection.AddScoped<GetComputerTypeUseCase>();
            

            // ComputerPhysicalLocation Use Cases
            serviceCollection.AddScoped<GetComputerPhysicalLocationCountUseCase>();
            serviceCollection.AddScoped<DeleteComputerPhysicalLocationUseCase>();
            serviceCollection.AddScoped<AddComputerPhysicalLocationUseCase>();
            serviceCollection.AddScoped<GetComputerPhysicalLocationUseCase>();
            

            // Campus Use Cases
            serviceCollection.AddScoped<GetCampusCountUseCase>();
            serviceCollection.AddScoped<DeleteCampusUseCase>();
            serviceCollection.AddScoped<AddCampusUseCase>();
            serviceCollection.AddScoped<GetCampusUseCase>();
            

            // Building Use Cases
            serviceCollection.AddScoped<GetBuildingCountUseCase>();
            serviceCollection.AddScoped<DeleteBuildingUseCase>();
            serviceCollection.AddScoped<AddBuildingUseCase>();
            serviceCollection.AddScoped<GetBuildingUseCase>();
            
            

            // Room Use Cases
            serviceCollection.AddScoped<GetRoomCountUseCase>();
            serviceCollection.AddScoped<DeleteRoomUseCase>();
            serviceCollection.AddScoped<AddRoomUseCase>();
            serviceCollection.AddScoped<GetRoomUseCase>();          
      
            return serviceCollection;
        }

        public static IServiceCollection AddInfrastructureLayerDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            // Database
            serviceCollection.AddDbContext<ComputerDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SqlServer"));
            });


            // Computer Repository
            serviceCollection.AddScoped<IComputerRepository, ComputerRepository>();

            // ComputerPhysicalLocation Repository
            serviceCollection.AddScoped<IComputerPhysicalLocationRepository, ComputerPhysicalLocationRepository>();

            // ComputerType Repository
            serviceCollection.AddScoped<IComputerTypeRepository, ComputerTypeRepository>();

            // Campus Repository
            serviceCollection.AddScoped<ICampusRepository, CampusRepository>();

            // Building Repository
            serviceCollection.AddScoped<IBuildingRepository, BuildingRepository>();

            // Room Repository
            serviceCollection.AddScoped<IRoomRepository, RoomRepository>();

            return serviceCollection;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Computer Management API",
                    Version = "v1"
                });
            });

            return services;
        }

        public static IServiceCollection AddApiVersioningConfiguration(this IServiceCollection services)
        {
            services
                .AddApiVersioning(options =>
                {
                    options.DefaultApiVersion = new ApiVersion(1.0);
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ReportApiVersions = true;
                })
                .AddApiExplorer(options =>
                {
                    options.GroupNameFormat = "'v'VVV";
                    options.SubstituteApiVersionInUrl = true;
                });

            return services;
        }
    }
}
