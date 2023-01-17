namespace TrueWind.RestApi;

public class Program
{
    public static int Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //builder.Services.AddSingleton<TrueWindAPI>();
        var app = builder.Build();
        app.UseHttpsRedirection();
        app.MapGet("/health", () => "healthy");

        app.Run();

        return 0;
    }
}

