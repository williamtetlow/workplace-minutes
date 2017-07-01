namespace mediator

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.Configuration
open Microsoft.Extensions.DependencyInjection
open Microsoft.Extensions.Logging
open mediator.Types.CommonTypes
open Persistence.Types
open Persistence.Interfaces

type Startup (env:IHostingEnvironment)=

    let builder = ConfigurationBuilder()
                    .SetBasePath(env.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile((sprintf "appsettings.%s.json" env.EnvironmentName), true)
                    .AddEnvironmentVariables()

    let configuration = builder.Build()

    // This method gets called by the runtime. Use this method to add services to the container.
    member this.ConfigureServices (services:IServiceCollection) =
        services.AddLogging() |> ignore
        // Adds services required for options
        services.AddOptions() |> ignore

        // Add Settings
        services.Configure<ApplicationOptions> configuration |> ignore
        
        // Add framework services.
        services.AddMvc() |> ignore

        // Dependency Injection
        let fileStorageDAO = 
          FileStorageDAOConfiguration.createGCPStorageConfig "workplace-minutes" "minutes-audio-recordings"
          |> FileStorageDAO.create

        services.AddSingleton(fileStorageDAO) |> ignore
        

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    member this.Configure(app:IApplicationBuilder, env:IHostingEnvironment, loggerFactory: ILoggerFactory) =
    
        loggerFactory
            .AddConsole(configuration.GetSection("Logging"))
            .AddDebug(LogLevel.Trace)
            |> ignore

        app.UseMvc() |> ignore    
    