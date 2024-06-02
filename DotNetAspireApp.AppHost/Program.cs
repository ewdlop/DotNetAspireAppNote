var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.DotNetAspireApp_ApiService>("apiservice");

builder.AddProject<Projects.DotNetAspireApp_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService);

builder.AddProject<Projects.DotNetAspireApp_WebAPI>("api");

builder.AddProject<Projects.DotNetAspireApp_WebAPINativeAOT>("apiaot");

builder.AddProject<Projects.ReactFullStack_Server>("reactfullstack-server");

builder.Build().Run();
