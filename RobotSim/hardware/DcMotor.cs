namespace RobotSim.hardware;

public class DcMotor
{
    public enum Configuration
    {
        LEFT_FRONT,
        RIGHT_FRONT,
        LEFT_BACK,
        RIGHT_BACK,

        FLY_WHEEL,
        TURRET,

        INTAKE_FRONT,
        INTAKE_BACK
    }

    public DcMotor(Configuration config)
    {
    }
}