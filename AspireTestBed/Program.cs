var builder = DistributedApplication.CreateBuilder(args);


var rabbit = builder.AddRabbitMQ("RabbitServer");

builder.AddProject<Projects.CustomerApi>("CustomerApi")
    .WithReference(rabbit);

builder.AddProject<Projects.WebhookSender>("WebhookSender")
    .WithReference(rabbit);


builder.Build().Run();