# .NET Core - Background Worker

### Install
``` powershell
PM> Install-Package Microsoft.Extensions.Hosting -Version 3.1.7
```

### Define a new Worker (with DI)
``` csharp
public class Worker : BackgroundService
{
    private readonly IType dependency;

    public Worker(IType dependency)
    {
        this.dependency = dependency;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // ..
        }
    }
}
```

### Worker Service setup
``` csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        await Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddTransient<IType, Type>();
                })
            .Build()
            .RunAsync()
            .ConfigureAwait(continueOnCapturedContext: false);
    }
}
```

### Web Application setup
``` csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        await Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .Build()
            .RunAsync()
            .ConfigureAwait(continueOnCapturedContext: false);
    }
}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        // ..

        services.AddSingleton<IType, Type>();
        services.AddSingleton<IHostedService, Worker>();

        // ..
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ..
    }
}
```