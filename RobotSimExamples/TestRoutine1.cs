using System.Diagnostics;
using RobotSim.routine;

namespace RobotSimExamples;

public class TestRoutine1 : Routine
{
    private static int timesExecuted = 0;
    private long lastTime = 0;

    public override void Start()
    {
        timesExecuted++;
        lastTime = Stopwatch.GetTimestamp() / TimeSpan.TicksPerMillisecond;
        Console.WriteLine("Starting " + timesExecuted);
    }

    public override void Loop()
    {
        long currTime = Stopwatch.GetTimestamp() / TimeSpan.TicksPerMillisecond;
        if (currTime - lastTime > 1000)
        {
            Console.WriteLine("Looping " + timesExecuted);
            lastTime = currTime;
        }
    }

    public override void Stop()
    {
        Console.WriteLine("Stopping " + timesExecuted);
    }
}