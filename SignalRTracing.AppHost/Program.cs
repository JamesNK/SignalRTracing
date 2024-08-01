var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.SignalRTracing_ApiService>("apiservice")
    .WithHttpEndpoint(port: 8080);

builder.AddProject<Projects.SignalRTracing_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService);

builder.Build().Run();
