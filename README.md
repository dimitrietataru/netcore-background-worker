# .NET Core - Background Worker

## Install
``` powershell
PM> Install-Package Microsoft.Extensions.Hosting -Version 3.1.10
```

## Structure
``` csharp
public class Worker : BackgroundService
{
    private readonly IServiceProvider serviceProvider;

    public Worker(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        using var scope = serviceProvider.CreateScope();
        var type = scope.ServiceProvider.GetRequiredService<IType>();
    
        while (!cancellationToken.IsCancellationRequested)
        {
            // ..
        }
    }
}
```

## Setup - Worker Service
``` csharp
public class Program
{
    public static async Task Main(string[] args)
    {
        await Host
            .CreateDefaultBuilder(args)
            .ConfigureServices((_, services) =>
                {
                    services.AddTransient<IType, Type>();
                    services.AddHostedService<Worker>();
                })
            .Build()
            .RunAsync()
            .ConfigureAwait(continueOnCapturedContext: false);
    }
}
```

## Setup - WebApp Worker
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

        services.AddScoped<IType, Type>();
        services.AddHostedService<Worker>();

        // ..
    }
}
```
