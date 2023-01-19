using TrueWind.Api;

namespace TrueWind.RestApi;

public class Program
{
    public static int Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddSingleton<TrueWindApi>();
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.MapGet("/health", () => "healthy");
        app.MapGet("/api/1/venue/1/forecast", () => app.Services.GetRequiredService<TrueWindApi>().GetForecast());

        app.Run();

        return 0;
    }
}

