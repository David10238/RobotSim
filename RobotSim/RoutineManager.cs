﻿using RobotSim.hardware;
using RobotSim.routine;

namespace RobotSim;

public static class RoutineManager
{
    private static readonly Dictionary<string, Func<Routine>> Routines = new();
    private static string _activeRoutine = "";

    private static readonly System.Threading.Lock RoutineLock = new();
    private static Thread? _routineThread;
    private static Thread? _halThread;
    private static volatile bool _killRoutine = false;
    private static volatile bool _killHAL = false;

    public static void RegisterRoutine(string name, Func<Routine> routineFunc)
    {
        Routines.Add(name, routineFunc);
    }

    public static void SwitchRoutine(string newRoutine)
    {
        lock (RoutineLock)
        {
            // cleanup the previous routine
            _KillRoutine();

            // startup a new hal
            HAL.Remake();
            _halThread = new Thread(() =>
            {
                while (!_killHAL)
                {
                    HAL.INSTANCE.UpdateSimulation();
                }

                _killHAL = false;
            });
            _halThread.Start();

            // launch a new thread
            var routineFunction = Routines[newRoutine];
            _routineThread = new Thread(() =>
            {
                var routine = routineFunction();

                routine.Start();

                while (!_killRoutine)
                {
                    routine.Loop();
                }

                routine.Stop();
                _killRoutine = false;
            });
            _routineThread.Start();

            _activeRoutine = newRoutine;
        }
    }

    public static void KillRoutine()
    {
        lock (RoutineLock)
        {
            _KillRoutine();
        }
    }

    public static string GetActiveRoutine()
    {
        lock (RoutineLock)
        {
            return _activeRoutine;
        }
    }

    private static void _KillRoutine()
    {
        lock (RoutineLock)
        {
            // make sure thread terminates
            if (_routineThread != null)
            {
                _killRoutine = true;
                _routineThread.Join();
            }

            _routineThread = null;
            _activeRoutine = "";

            // make sure HAL terminates

            if (_halThread != null)
            {
                _killHAL = true;
                _halThread.Join();
            }

            _halThread = null;
        }
    }
}