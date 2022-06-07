namespace Upsub.Server.Api;

public static class DevelopmentCorsExtensions
{
    private const string CorsPolicyName = "AllowAllCorsPolicy";

    public static void AddCorsForDevelopment(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(CorsPolicyName, policy =>
            {
                policy.WithOrigins("http://localhost:3000", "http://127.0.0.1:3000");
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowCredentials();
            });
        });
    }

    public static void UseCorsForDevelopment(this WebApplication app)
    {
        app.UseCors(CorsPolicyName);
    }
}
