using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ServiceDefaults;

namespace CustomerWorker
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var app = CreateHostBuilder(args).Build();

            await app.RunAsync();
        }

        public static HostApplicationBuilder CreateHostBuilder(string[] args)
        {
            var builder = Host.CreateApplicationBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("RabbitServer");
            builder.Services.AddMassTransit(x =>
            {
                x.AddConsumer<ConsumeMyMessage>();
                x.AddMetrics();
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(connectionString);
                    cfg.ConfigureEndpoints(context);
                });
                x.SetKebabCaseEndpointNameFormatter();
            });
            builder.AddServiceDefaults();

            return builder;
        }
        
    }
    
}