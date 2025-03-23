using System.Net.Http.Headers;
using RobotSim.hardware;
using RobotSim.routine;

namespace RobotSimExamples;

public class LiftTest : Routine
{
    public override void Start()
    {
    }

    public override void Loop()
    {
        double target = 80.0;
        double position = HAL.INSTANCE.Lift.Position;

        double kP = 0.1;
        HAL.INSTANCE.Lift.Power = kP * (target - position);

        Console.WriteLine();
        Console.WriteLine(position);
        Console.WriteLine(HAL.INSTANCE.Lift.Power);
    }

    public override void Stop()
    {
    }
}