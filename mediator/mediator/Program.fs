// Learn more about F# at http://fsharp.org

open System
open System.IO
open Microsoft.Extensions.Configuration
open Microsoft.AspNetCore.Hosting

open mediator

[<EntryPoint>]
let main argv =

    let config = ConfigurationBuilder()
                    .AddCommandLine(argv)
                    .AddEnvironmentVariables("ASPNETCORE_")
                    .Build()

    let host = WebHostBuilder()
                    .UseConfiguration(config)
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    // listen on port 5000 on all network interfaces
                    // see http://blog.scottlogic.com/2016/09/05/hosting-netcore-on-linux-with-docker.html
                    .UseUrls("http://*:5000") 
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .Build()
    host.Run();

    0 // return an integer exit code
