namespace RobotSim.hardware;

public class Lift
{
    private const double SpoolRadius = 1.5;
    private const int NumberMotors = 2;
    private const double GearRatio = 5.2;

    private double _power = 0.0;

    public double Power
    {
        get { return _power; }
        set
        {
            Thread.Sleep(3 * NumberMotors);
            _power = value;
        }
    }

    public double Position { get; private set; }


    public void UpdateSimulation(double dt)
    {
        var power = Math.Clamp(_power, -1.0, 1.0);
        var radPerSecond = power * GoBILDAMotor.MAX_RAD_PER_SECOND / GearRatio;

        Position += SpoolRadius * radPerSecond * dt;
    }
}