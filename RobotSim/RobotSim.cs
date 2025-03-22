namespace RobotSim;

public static class RobotSim
{
    
    
    public static void RegisterRoutine(string name, Action routine)
    {
    }

    public static void Luanch(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}