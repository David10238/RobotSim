using RobotSim;
using RobotSimExamples;

RoutineManager.RegisterRoutine("test1", () => new TestRoutine1());

RoutineManager.SwitchRoutine("test1");
Thread.Sleep(2000);

RoutineManager.SwitchRoutine("test1");
Thread.Sleep(2000);

RoutineManager.KillRoutine();
RoutineManager.SwitchRoutine("test1");
Thread.Sleep(4000);
RoutineManager.KillRoutine();

RobotSim.RobotSim.Launch(args);