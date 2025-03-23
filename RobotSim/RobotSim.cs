namespace RobotSim;

public static class RobotSim
{
    public static void Launch(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}