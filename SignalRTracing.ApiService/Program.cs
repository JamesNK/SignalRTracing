using SignalRTracing.ApiService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

builder.Logging.SetMinimumLevel(LogLevel.Trace);

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing =>
    {
        tracing
            .AddSource("Microsoft.AspNetCore.SignalR.Server");
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseExceptionHandler();
app.UseWebSockets();

app.MapHub<ChatHub>("/chathub");

app.MapDefaultEndpoints();

app.Run();
