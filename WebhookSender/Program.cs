// See https://aka.ms/new-console-template for more information



HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

IHost host = builder.Build();
host.Run();

Console.WriteLine("Hello, World!");