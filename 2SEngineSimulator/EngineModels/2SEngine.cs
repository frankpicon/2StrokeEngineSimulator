using System;
using System.Collections.Generic;
using System.Text;
using _2SEngineSimulator.Interfaces;
using System.Threading;

namespace _2SEngineSimulator.EngineModels
{
    public class _2SEngine : IEngine
    {
       public string ModelName { get; set; }
        public SparkPlug SparkPlug { get; }
        public Piston Piston { get;  }
        public CrankShaft CrankShaft { get; }
        public RodController RodController { get; }
        public _2SEngine ( SparkPlug sparkPlug, Piston piston,CrankShaft crankShaft, RodController rodController)
        {
            this.RodController = rodController;
            this.Piston = piston;
            this.SparkPlug = sparkPlug;
            this.CrankShaft = crankShaft;
        }

        public void StartEngine()
        {
            EngineStates.EchoEngineState(EngineStates.EngineStart +$"({this.ModelName})");

            //Connect a Piston and a CrankShaft to the RodController by injecting it to the RodController Constructor
            //By decoupling the Piston and Crankshaft we can change the Piston Model or the Crankshaft Model types
            RodController rodController = new RodController(this.Piston, this.CrankShaft) { ModelName = this.RodController.ModelName};

            //How fast will the engine run and for How Long ?? Currently setting the engine to run for 4 cycles.
            int cycles = 4;
            WaitHandle[] waitHandles = new WaitHandle[cycles];

            for (int cycle = 0; cycle < cycles; cycle++)
            {

                // Set the Piston into Motion by the RodController
                var PistonMotionHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                var PistonMotion = new Thread(() =>
                {
                    rodController.Move(IRodController.Direction.Up);
                    rodController.Move(IRodController.Direction.Down);

                    Console.WriteLine($"Cycle {cycle + 1} complete. By Controller ({rodController.ModelName})");
                    PistonMotionHandle.Set();
                });
                waitHandles[cycle] = PistonMotionHandle;
                PistonMotion.Start();
                PistonMotion.Join(); //This ensures that only one full Piston Motion cycle (2stroke) must complete before starting the next Motion cycle
            }

            //Wait for all the Piston Movements to complete before stopping the Engine. 
            WaitHandle.WaitAll(waitHandles);
            EngineStates.EchoEngineState(EngineStates.EngineStopped + $"({this.ModelName})");

            Console.Read();
        }




    }
    public static class EngineStates
    {

        public const string EngineStart = "Engine Started";
        public const string EngineStopped = "Engine Stopped";
        public const string PistonUp = "Piston Moving Up.....";
        public const string PistonDown = "Piston Moving Down.....";
        public const string PistonUpComplete = "Moving Up Complete Piston at TOP."; 
        public const string PistonDownComplete = "Moving Down Complete Piston at Bottom.";
        public const string FirstStrokeComplete = "1 Stroke Complete.";
        public const string SecondStrokeComplete = "2 Stroke Complete.";
        public static void EchoEngineState(String description)
        {
            Console.WriteLine($"{description}");
        }
    }


}
