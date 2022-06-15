using Upsub.Server.Api;
using Upsub.Server.Api.RealTimeCommunication;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
if (IsDevelopment())
    builder.Services.AddCorsForDevelopment();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (IsDevelopment())
    app.UseCorsForDevelopment();
app.MapHub<DashboardFeedHub>("dashboard-feed");
app.MapControllers();

app.Run();

bool IsDevelopment() =>
    Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";
