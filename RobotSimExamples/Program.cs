using RobotSim;
using RobotSimExamples;

RoutineManager.RegisterRoutine("test1", () => new TestRoutine1());

RobotSim.RobotSim.Launch(args);