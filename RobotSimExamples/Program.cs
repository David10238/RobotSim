using RobotSim;
using RobotSimExamples;

RoutineManager.RegisterRoutine("test1", () => new TestRoutine1());
RoutineManager.RegisterRoutine("test2", () => new LiftTest());

RobotSim.RobotSim.Launch(args);