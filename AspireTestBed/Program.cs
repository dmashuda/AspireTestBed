using Microsoft.AspNetCore.Identity;

var builder = DistributedApplication.CreateBuilder(args);


var rabbit = builder.AddRabbitMQ("RabbitServer")
    .WithDataVolume("rabbitmq-volume")
    .WithHealthCheck()
    .WithManagementPlugin(15672);

var api = builder.AddProject<Projects.CustomerApi>("CustomerApi")
    .WithReference(rabbit)
    .WaitFor(rabbit);

builder.AddProject<Projects.CustomerWorker>("CustomerWorker")
    .WithReference(rabbit)
    .WaitFor(rabbit)
    .WaitFor(api);


builder.Build().Run();