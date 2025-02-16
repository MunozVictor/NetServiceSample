using WineCorp.Api;
using WineCorp.Infrastructure.Context;
using WineCorp.Service.ServiceCollection;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .AddCommandLine(args);


builder.Services.AddControllers();

ApiConfiguration.ConfigureServices(builder.Services);

builder.Services.AddRegisterTypes();


var app = builder.Build();

ApiConfiguration.Configure(app);

app.Run();
