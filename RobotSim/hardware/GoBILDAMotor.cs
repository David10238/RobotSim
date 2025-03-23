namespace RobotSim.hardware;

public static class GoBILDAMotor
{
    public static readonly double TORQUE = 1.5 * 0.0980665; // in N*m
    public static readonly double MAX_RPM = 6000;

    public static readonly double TICKS_PER_ROTATION = 28;

    public static readonly double MAX_RAD_PER_SECOND = 2 * Math.PI * MAX_RPM / 60;
}