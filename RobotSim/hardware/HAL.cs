using System.Diagnostics;

namespace RobotSim.hardware;

public class HAL
{
    public static HAL INSTANCE { private set; get; }

    public readonly Lift Lift = new Lift();

    private double _lastTime = Stopwatch.GetTimestamp() / (double)TimeSpan.TicksPerMillisecond;

    private HAL()
    {
    }

    public static void Remake()
    {
        INSTANCE = new HAL();
    }

    public void UpdateSimulation()
    {
        double currTime = Stopwatch.GetTimestamp() / (double)TimeSpan.TicksPerMillisecond;
        double diff = currTime - _lastTime;

        if (diff < 0.1) // 10,000hz simulation
        {
            return;
        }

        double dt = diff / 1000.0;
        _lastTime = currTime;

        Lift.UpdateSimulation(dt);
    }
}